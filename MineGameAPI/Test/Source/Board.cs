using System.Diagnostics;

namespace LandmineGameClasses
{
    public enum BoardSquare
    {
        Empty,
        Mine,
        Life
    }
    public class Board
    {
        // Board array accessed using 'y' to get rows going from top to bottom
        // Then each element in the row is accessed from left to right using 'x'

        // In order to make coords (0, 0) the bottom left square, the 'y' value should be inverted
        // boardArray[boardArray.Count() - 1 - y][x]

        private static readonly string[] BOARD_SQUARE_STRINGS = { "~ ", "X ", "+ " };
        private static readonly string BORDER_STRING = "|";

        public readonly int width;
        public readonly int height;
        public BoardSquare[][] boardArray { get; }

        public Board(int width, int height) {

            Debug.Assert(width > 0 && width <= 10 && height > 0 && height <= 10, "[ERROR] Max board width and height is 10, minimum is 1"); // Max board width and height of 10, otherwise displaying the board becomes more complex

            this.width = width;
            this.height = height;

            boardArray = new BoardSquare[height][];
            for (int i = 0; i < height; i++)
            {
                boardArray[i] = new BoardSquare[width];
                for (int j = 0; j < width; j++)
                {
                    boardArray[i][j] = BoardSquare.Empty;
                }
            }
        }

        public void placeMine(int x, int y)
        {
            boardArray[boardArray.Count() - y - 1][x] = BoardSquare.Mine;
        }

        public void placeLife(int x, int y)
        {
            boardArray[boardArray.Count() - y - 1][x] = BoardSquare.Life;
        }

        public void clearSquare(int x, int y)
        {
            boardArray[boardArray.Count() - y - 1][x] = BoardSquare.Empty;
        }

        public BoardSquare squareAt(int x, int y)
        {
            return boardArray[boardArray.Count() - y - 1][x];
        }

        public string getJSON()
        {
            // Generate JSON array containing board square values
            string json = "[";
            for (var i = 0; i < height; i++)
            {
                string row = "[";
                for (var j = 0; j < width; j++)
                {
                    row += ((int)boardArray[i][j]).ToString();
                    if (j != width - 1)
                    {
                        row += ",";
                    }
                }
                row += "]";
                if (i != height - 1)
                {
                    row += ",";
                }
                json += row;
            }
            json += "]";
            return json;
        }

        public string getDisplayString()
        {
            string displayString = "";
            for (int i = 0; i < height; i++)
            {
                // Y axis and left border
                string rowString = (height - i - 1).ToString() + " " + BORDER_STRING;

                for (int j = 0; j < width; j++)
                {
                    // Convert enum to integer giving 0 for an empty square, 1 for a mine, and 2 for a life
                    rowString += BOARD_SQUARE_STRINGS[(int)boardArray[i][j]]; 
                }
                // Right border
                displayString += rowString + BORDER_STRING + "\n"; 
            }

            // X axis
            displayString += "Y\n X ";
            for (int i = 0; i < width; i++)
            {
                displayString += i.ToString();
                if (i != width - 1)
                    displayString += " ";
            }

            return displayString;
        }

        public Player createPlayer(int startingX, int startingY, int startingLives)
        {
            // Create Player instance via private constructor
            object? playerObject = Activator.CreateInstance(typeof(Player), true);
            Debug.Assert(playerObject is not null, "[ERROR] Newly created Player object was null");

            // Initialize player
            Player player = (Player)playerObject;
            player.initialise(startingX, startingY, startingLives, width, height);

            return player;
        }
    }
}
