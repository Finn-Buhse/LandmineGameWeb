using LandmineGameClasses;

namespace Testing
{
    [TestClass]
    public class BoardTests
    {
        const string EMPTY_DISPLAY_STRING_DUMMY = "7 |~ ~ ~ ~ ~ ~ ~ ~ |\n6 |~ ~ ~ ~ ~ ~ ~ ~ |\n5 |~ ~ ~ ~ ~ ~ ~ ~ |\n4 |~ ~ ~ ~ ~ ~ ~ ~ |\n3 |~ ~ ~ ~ ~ ~ ~ ~ |\n2 |~ ~ ~ ~ ~ ~ ~ ~ |\n1 |~ ~ ~ ~ ~ ~ ~ ~ |\n0 |~ ~ ~ ~ ~ ~ ~ ~ |\nY\n X 0 1 2 3 4 5 6 7";

        // Mine coordinates are:
        // (0, 0)
        // (7, 7)
        // (2, 5)
        // (6, 4) 
        const string PLACED_MINES_DISPLAY_STRING_DUMMY = "7 |~ ~ ~ ~ ~ ~ ~ X |\n6 |~ ~ ~ ~ ~ ~ ~ ~ |\n5 |~ ~ X ~ ~ ~ ~ ~ |\n4 |~ ~ ~ ~ ~ ~ X ~ |\n3 |~ ~ ~ ~ ~ ~ ~ ~ |\n2 |~ ~ ~ ~ ~ ~ ~ ~ |\n1 |~ ~ ~ ~ ~ ~ ~ ~ |\n0 |X ~ ~ ~ ~ ~ ~ ~ |\nY\n X 0 1 2 3 4 5 6 7";

        Board? board = null;

        // GIVENS

        public void givenBoardCreatedWithWidthAndHeightEqualTo8()
        {
            board = new Board(8, 8);
        }

        public void givenMinePlacedAtXEquals0YEquals7() 
        {
            board!.placeMine(0, 7);
        }

        public void givenSomeMinesArePlaced()
        {
            board!.placeMine(0, 0);
            board!.placeMine(7, 7);
            board!.placeMine(2, 5);
            board!.placeMine(6, 4);
        }

        // THENS

        public void thenBoardArrayHasLengthEqualTo8ContainingArraysWithLengthsEqualTo8()
        {
            Assert.AreEqual(board!.boardArray.Count(), 8);
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(8, board!.boardArray[i].Count());
            }
        }

        public void thenBoardHasNoMines()
        {
            bool mineFound = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mineFound |= board!.boardArray[i][j] == BoardSquare.Mine;
                }
            }
            Assert.IsFalse(mineFound);
        }

        public void thenBoardSquareAtXEquals0YEquals7IsEmpty()
        {
            Assert.AreEqual(BoardSquare.Empty, board!.squareAt(0, 7));
        }

        public void thenBoardSqaureAtXEquals0YEquals7IsMine()
        {
            Assert.AreEqual(BoardSquare.Mine, board!.squareAt(0, 7));
        }

        public void thenDisplayStringIsCorrectForEmptyBoard()
        {
            Assert.AreEqual(EMPTY_DISPLAY_STRING_DUMMY, board!.getDisplayString());
        }

        public void thenDisplayStringIsCorrectForPlacedMines()
        {
            Assert.AreEqual(PLACED_MINES_DISPLAY_STRING_DUMMY, board!.getDisplayString());
        }

        [TestMethod]
        public void CreatedBoardHasArrayWithCorrectDimensions()
        {
            givenBoardCreatedWithWidthAndHeightEqualTo8();
            thenBoardArrayHasLengthEqualTo8ContainingArraysWithLengthsEqualTo8();
        }

        [TestMethod]
        public void CreatedBoardHasNoMines()
        {
            givenBoardCreatedWithWidthAndHeightEqualTo8();
            thenBoardHasNoMines();
        }

        [TestMethod]
        public void MineCanBePlacedOnBoardCoordinate()
        {
            givenBoardCreatedWithWidthAndHeightEqualTo8();
            givenMinePlacedAtXEquals0YEquals7();
            thenBoardSqaureAtXEquals0YEquals7IsMine();
        }

        [TestMethod]
        public void CoordinatesOfBoardCanBeQueriedForMine()
        {
            givenBoardCreatedWithWidthAndHeightEqualTo8();
            thenBoardSquareAtXEquals0YEquals7IsEmpty();

            givenMinePlacedAtXEquals0YEquals7();
            thenBoardSqaureAtXEquals0YEquals7IsMine();
        }

        public void BoardReturnsCorrectJSON()
        {
            givenBoardCreatedWithWidthAndHeightEqualTo8();

            /*
            thenDisplayStringIsCorrectForEmptyBoard();

            givenSomeMinesArePlaced();

            thenDisplayStringIsCorrectForPlacedMines();
            */
        }

        [TestMethod]
        public void BoardReturnsCorrectDisplayString()
        {
            givenBoardCreatedWithWidthAndHeightEqualTo8();

            thenDisplayStringIsCorrectForEmptyBoard();

            givenSomeMinesArePlaced();

            thenDisplayStringIsCorrectForPlacedMines();
        }
    }
}