using LandmineGameClasses;

namespace Testing
{
    [TestClass]
    public class PlayerTests
    {
        Board? mockBoard = null;
        Player? player = null;

        // Board width and height are equal to 8 for these tests
        void givenABoardWithWidthAndHeightEqualTo8()
        {
            mockBoard = new Board(8, 8);
        }

        void givenAPlayerIsCreatedWithXAndYEqualTo0()
        {
            player = mockBoard!.createPlayer(0, 0, 3); 
        }

        void givenAPlayerIsCreatedWithXAndYEqualTo7()
        {
            player = mockBoard!.createPlayer(7, 7, 3);
        }

        void whenThePlayerMovesUp()
        {
            player!.move(Player.MovementDirection.Up);
        }
        void whenThePlayerMovesDown()
        {
            player!.move(Player.MovementDirection.Down);
        }
        void whenThePlayerMovesLeft()
        {
            player!.move(Player.MovementDirection.Left);
        }
        void whenThePlayerMovesRight()
        {
            player!.move(Player.MovementDirection.Right);
        }

        void thenPlayerXAndYMembersEqual0()
        {
            Assert.AreEqual(0, player!.x);
            Assert.AreEqual(0, player!.y);
        }

        void thenPlayerXAndYMembersEqual7()
        {
            Assert.AreEqual(7, player!.x);
            Assert.AreEqual(7, player!.y);
        }

        void thenPlayerXEquals0AndYEquals1()
        {
            Assert.AreEqual(0, player!.x);
            Assert.AreEqual(1, player!.y);
        }
        void thenPlayerXEquals7AndYEquals6()
        {
            Assert.AreEqual(7, player!.x);
            Assert.AreEqual(6, player!.y);
        }

        void thenPlayerXEquals6AndYEquals7()
        {
            Assert.AreEqual(6, player!.x);
            Assert.AreEqual(7, player!.y);
        }

        void thenPlayerXEquals1AndYEquals0()
        {
            Assert.AreEqual(1, player!.x);
            Assert.AreEqual(0, player!.y);
        }

        [TestMethod]
        public void PlayerMovesUpToCorrectCoordinates()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo0();

            whenThePlayerMovesUp();
            thenPlayerXEquals0AndYEquals1();
        }

        [TestMethod]
        public void PlayerMovesDownToCorrectCoordinates()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo7();

            whenThePlayerMovesDown();
            thenPlayerXEquals7AndYEquals6();
        }

        [TestMethod]
        public void PlayerMovesLeftToCorrectCoordinates()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo7();

            whenThePlayerMovesLeft();
            thenPlayerXEquals6AndYEquals7();
        }

        [TestMethod]
        public void PlayerMovesRightToCorrectCoordinates()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo0();

            whenThePlayerMovesRight();
            thenPlayerXEquals1AndYEquals0();
        }

        [TestMethod]
        public void PlayerDoesNotMoveUpOutOfBoard()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo7();

            whenThePlayerMovesUp();
            thenPlayerXAndYMembersEqual7();
        }

        [TestMethod]
        public void PlayerDoesNotMoveDownOutOfBoard()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo0();

            whenThePlayerMovesDown();
            thenPlayerXAndYMembersEqual0();
        }

        [TestMethod]
        public void PlayerDoesNotMoveLeftOutOfBoard()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo0();

            whenThePlayerMovesLeft();
            thenPlayerXAndYMembersEqual0();
        }

        [TestMethod]
        public void PlayerDoesNotMoveRightOutOfBoard()
        {
            givenABoardWithWidthAndHeightEqualTo8();
            givenAPlayerIsCreatedWithXAndYEqualTo7();

            whenThePlayerMovesRight();
            thenPlayerXAndYMembersEqual7();
        }
    }
}
