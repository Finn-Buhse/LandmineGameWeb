using RandomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LandmineGameClasses.LandmineGame;

namespace LandmineGameClasses
{
    public class LandmineGame
    {
        private static RandomGenerator randomGenerator = new RandomGenerator();

        // Internal for tests
        internal Board? board = null;
        internal Player? player = null;

        private int boardWidth = 8;
        private int boardHeight = 8;

        private GameInfo lastFrameGameInfo;

        public void setBoardWidthHeightInitialiseHints(int boardWidth, int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
        }

        public void initialise()
        {
            // Create board
            board = new Board(boardWidth, boardHeight);

            // Create new player at coordinates (0, 0) with 3 lives
            player = board.createPlayer(0, 0, 3);

            placeRandomMinesAndLives();
        }

        private void placeRandomMinesAndLives()
        {
            if(board != null)
            {
                for (int x = 0; x < boardWidth; x++)
                {
                    for (int y = 0; y < boardHeight; y++)
                    {
                        // Value can be 0, 1, or 2, giving
                        // a 1/3 probability of the square being empty
                        // a 1/3 probability of the square having a mine
                        // a 1/3 probability of the square having a life
                        int randomInt = randomGenerator.getRandom(0, 3);

                        // 0 corressponds to an empty square but nothing has to be done in this case since the board starts with empty squares
                        if (randomInt == 1)
                        {
                            board.placeMine(x, y);
                        }
                        else if (randomInt == 2)
                        {
                            board.placeLife(x, y);
                        }
                    }
                }
            }
        }

        public void movePlayer(Player.MovementDirection movementDirection)
        {
            if(player != null)
                player.move(movementDirection);
        }

        public void processFrame()
        {
            lastFrameGameInfo = updateGame();
        }

        public string getFrameJSON()
        {
            return generateFrameJSON(lastFrameGameInfo);
        }

        public string getFrameDisplayString()
        {
            return generateFrameDisplayString(lastFrameGameInfo);
        }

        public bool shouldEnd()
        {
            return lastFrameGameInfo.gameShouldEnd();
        }

        // Internal for LandmineGameTests
        internal enum PlayerStatus
        {
            Alive,
            Lost,
            Won
        }

        internal struct GameInfo
        {
            public BoardSquare playerVisitedSquare;
            public PlayerStatus playerStatus;

            public bool gameShouldEnd()
            {
                // If not Alive, the player will either have Won or Lost, in which case the game should end
                return playerStatus != PlayerStatus.Alive;
            }
        }

        internal GameInfo updateGame()
        {
            GameInfo gameInfo = new GameInfo();

            if(board != null)
            {
                if(player != null)
                {
                    // Obtain the square the player is currently on
                    gameInfo.playerVisitedSquare = board.squareAt(player.x, player.y);

                    // Process the player's lives, and whether they have won or lost
                    gameInfo.playerStatus = processPlayerStatus(gameInfo.playerVisitedSquare);

                    // Clear the square the player has visited
                    if (gameInfo.playerVisitedSquare != BoardSquare.Empty)
                        board.clearSquare(player.x, player.y);
                }
            }

            return gameInfo;
        }

        // If the player has o life left and hits a mine on the top row they could be considered to have won or lost,
        // for this game the player loses in this scenario
        internal PlayerStatus processPlayerStatus(BoardSquare playerVisitedSquare)
        {
            if(board != null)
            {
                if (player != null)
                {
                    // If player hits a mine deduct a life
                    if (playerVisitedSquare == BoardSquare.Mine)
                    {
                        player.deductLife();
                    } // If player hits a life add one to the player's lives
                    else if (playerVisitedSquare == BoardSquare.Life)
                    {
                        player.addLife();
                    }

                    // If player lives equals zero they have lost
                    if (player.isDead())
                    {
                        return PlayerStatus.Lost;

                    } // If player has reached the top row of the board they have won
                    else if (player.y == board.height - 1)
                    {
                        return PlayerStatus.Won;

                    }

                    return PlayerStatus.Alive;
                }
            }
            
            return PlayerStatus.Lost;
        }

        private string generateFrameJSON(GameInfo gameInfo)
        {
            if (board != null)
            {
                if (player != null)
                {
                    string json = "{";

                    json += "\"board\":" + board.getJSON() + ",";
                    json += "\"playerX\":" + player.x.ToString() + ",";
                    json += "\"playerY\":" + player.y.ToString() + ",";
                    json += "\"playerStatus\":" + ((int)gameInfo.playerStatus).ToString() + ",";
                    json += "\"playerVisitedSquare\":" + ((int)gameInfo.playerVisitedSquare).ToString();

                    json += "}";
                    return json;
                }
            }
            return "";
        }

        private string generateFrameDisplayString(GameInfo gameInfo)
        {
            if(board != null)
            {
                if (player != null)
                {
                    string result = "";
                    if (gameInfo.playerStatus == PlayerStatus.Won)
                    {
                        result += "You won!\n";
                    }
                    else if (gameInfo.playerStatus == PlayerStatus.Lost)
                    {
                        result += "You hit 3 mines! Game over!\n";
                    }
                    else
                    {
                        result +=
                            "Board:\n" + board.getDisplayString() +
                            "\nPlayer coordinates: (" + player.x.ToString() + ", " + player.y.ToString() + ")\n"
                            + (gameInfo.playerVisitedSquare == BoardSquare.Mine ? "You hit a mine!" : "You did not hit any mines.");
                    }
                    return result;
                }
            }
            return "";
        }
    }
}
