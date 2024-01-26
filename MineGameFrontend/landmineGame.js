// APP
const HTTP_UNSENT = 0;
const HTTP_OPENED = 1;
const HTTP_HEADERS_RECEIVED = 2;
const HTTP_LOADING = 3;
const HTTP_DONE = 4;

const PLAYER_STATUS_ALIVE = 0;
const PLAYER_STATUS_LOST = 1;
const PLAYER_STATUS_WON = 2;

const BOARD_SQUARE_EMPTY = 0;
const BOARD_SQUARE_MINE = 1;
const BOARD_SQUARE_HEALTH = 2;

// Initialise the game and perform update to show the first frame
initialise(8, 8, () => {
    updateGame();
});

/* Moves player, followed by updating the game */
function movePlayerUpButtonPressed()
{
    movePlayer(0, () => {
        updateGame();
    });
}

function movePlayerDownButtonPressed()
{
    movePlayer(1, () => {
        updateGame();
    });
}

function movePlayerLeftButtonPressed()
{
    movePlayer(2, () => {
        updateGame();
    });
}

function movePlayerRightButtonPressed()
{
    movePlayer(3, () => {
        updateGame();
    });
}

function updateGame()
{
    processFrame(() => {
        getFrame((frameJSON) => {
            updateUI(frameJSON)
        });
    });
}

function updateUI(frameJSON)
{
    var boardDisplay = document.getElementById("boardDisplay1"); // Obtain custom web-component
    var gameText = document.getElementById("gameText1");
    var inputs = document.getElementById("inputs1");

    // Update board
    boardDisplay.setGridSquares(frameJSON["board"]);

    // Update game text
    var playerStatus = frameJSON["playerStatus"];
    var text = ""
    if(playerStatus == PLAYER_STATUS_LOST)
    {
        text += "You lost!";
        boardDisplay.hide();
        inputs.hidden = true;
    }
    else if(playerStatus == PLAYER_STATUS_WON)
    {
        text += "You won!";
        boardDisplay.hide();
        inputs.hidden = true;
    }
    else if(playerStatus == PLAYER_STATUS_ALIVE)
    {
        text += "Player location: (" + frameJSON["playerX"].toString() + ", " + frameJSON["playerY"].toString() + ")<br>";

        var playerVisitedSquare = frameJSON["playerVisitedSquare"];
        if(playerVisitedSquare == BOARD_SQUARE_EMPTY)
        {
            text += "You did not hit any mines.";
        }
        else if(playerVisitedSquare == BOARD_SQUARE_MINE)
        {
            text += "You hit a mine!";
        }
        else if(playerVisitedSquare == BOARD_SQUARE_HEALTH)
        {
            text += "You gained a life!";
        }
    }
    gameText.innerHTML = text;
}

// API CONNECT
function initialise(width, height, finishCallback)
{
    const request = new XMLHttpRequest();
    const url = "https://localhost:7298/MineGameInitialise?width=" + width.toString() + "&height=" + height.toString();

    request.open("PUT", url);
    request.send();

    request.onreadystatechange = (event) => {
        if(request.readyState == HTTP_DONE)
        {
            finishCallback();
        }
    };
}

function movePlayer(movementDirection, finishedCallback)
{
    const request = new XMLHttpRequest();
    const url = "https://localhost:7298/MineGamePlayer?movementDirection=" + movementDirection.toString();

    request.open("PUT", url);
    request.send();

    request.onreadystatechange = (event) => {
        if(request.readyState == HTTP_DONE)
        {
            finishedCallback();
        }
    };
}

function processFrame(finishCallback)
{
    const request = new XMLHttpRequest();
    const url = "https://localhost:7298/MineGameFrame";

    request.open("PUT", url);
    request.send();

    request.onreadystatechange = (event) => {
        if(request.readyState == HTTP_DONE)
        {
            finishCallback();
        }
    };
}

function getFrame(frameCallback)
{
    const request = new XMLHttpRequest();
    request.responseType = "json";

    const url = "https://localhost:7298/MineGameFrame";

    request.open("GET", url);
    request.send();

    request.onreadystatechange = (event) => {
        if(request.readyState == HTTP_DONE)
        {
            frameCallback(request.response);
        }
    };
}