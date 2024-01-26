using LandmineGameClasses;

namespace Testing
{
    [TestClass]
    public class LandmineGameTests
    {
        LandmineGame? mockLandmineGame = null;

        void givenALandmineGame()
        {
            mockLandmineGame = new LandmineGame();
            mockLandmineGame.initialise();
        }

        void givenThePlayerHitsAMineAndIsBelowTheTopRow()
        {
            // Mocks the sequence of actions that would occur the in game loop
            // - Game first processes player status
            // - Followed by moving the player in the direction given by user

            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Mine));
            mockLandmineGame!.player!.move(Player.MovementDirection.Up);
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Empty));
            mockLandmineGame.player.move(Player.MovementDirection.Up);
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Empty));
            mockLandmineGame!.player!.move(Player.MovementDirection.Up);
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Empty));
            mockLandmineGame!.player!.move(Player.MovementDirection.Up);
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Empty));
            mockLandmineGame!.player!.move(Player.MovementDirection.Up);
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Empty));
            mockLandmineGame!.player!.move(Player.MovementDirection.Up);
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Empty));
        }

        void givenThePlayerHitsAMine()
        {
            Assert.AreEqual(LandmineGame.PlayerStatus.Alive, mockLandmineGame!.processPlayerStatus(BoardSquare.Mine));
        }

        void givenAMineIsPlacedOnTheBoardAtXAndYEquals0()
        {
            mockLandmineGame!.board!.placeMine(0, 0);
        }

        void givenALifeIsPlacedOnTheBoardAtXAndYEquals0()
        {
            mockLandmineGame!.board!.placeLife(0, 0);
        }

        void whenPlayerMovesUp()
        {
            mockLandmineGame!.player!.move(Player.MovementDirection.Up);
        }

        void whenUpdateGameIsCalled()
        {
            mockLandmineGame!.updateGame();
        }

        void thenIfPlayerHitsASecondMinePlayerStatusReturnsWon()
        {
            Assert.AreEqual(LandmineGame.PlayerStatus.Won, mockLandmineGame!.processPlayerStatus(BoardSquare.Mine));
        }

        void thenIfPlayerHitsAThirdMinePlayerStatusReturnsLost()
        {
            Assert.AreEqual(LandmineGame.PlayerStatus.Lost, mockLandmineGame!.processPlayerStatus(BoardSquare.Mine));
        }

        void thenTheBoardSquareIsEmpty()
        {
            Assert.AreEqual(BoardSquare.Empty, mockLandmineGame!.board!.boardArray[7][0]); // Board square at coordinates (0, 0)
        }

        void thenThePlayersLivesIsEqualTo2()
        {
            Assert.AreEqual(2, mockLandmineGame!.player!.lives);
        }

        void thenThePlayersLivesIsEqualTo3()
        {
            Assert.AreEqual(3, mockLandmineGame!.player!.lives);
        }

        void thenThePlayersLivesIsEqualTo4()
        {
            Assert.AreEqual(4, mockLandmineGame!.player!.lives);
        }

        [TestMethod]
        public void GetPlayerStatusCorrectlyReturnsWon()
        {
            givenALandmineGame();
            givenThePlayerHitsAMineAndIsBelowTheTopRow();

            whenPlayerMovesUp();

            thenIfPlayerHitsASecondMinePlayerStatusReturnsWon();
        }

        [TestMethod]
        public void GetPlayerStatusCorrectlyReturnsLost()
        {
            givenALandmineGame();
            givenThePlayerHitsAMineAndIsBelowTheTopRow();
            givenThePlayerHitsAMine();

            whenPlayerMovesUp();

            thenIfPlayerHitsAThirdMinePlayerStatusReturnsLost();
        }

        [TestMethod]
        public void WhenPlayerIsOnMineOrLifeUpdateGameSetsBoardSquareToEmpty()
        {
            givenALandmineGame();
            givenAMineIsPlacedOnTheBoardAtXAndYEquals0();

            whenUpdateGameIsCalled();

            thenTheBoardSquareIsEmpty();
        }

        [TestMethod]
        public void WhenPlayerIsOnMinePlayerStatusDecrementsPlayerLives()
        {
            givenALandmineGame();
            givenAMineIsPlacedOnTheBoardAtXAndYEquals0();

            thenThePlayersLivesIsEqualTo3();

            whenUpdateGameIsCalled();

            thenThePlayersLivesIsEqualTo2();
        }

        [TestMethod]
        public void WhenPlayerIsOnLifePlayerStatusIncrementsPlayerLives()
        {
            givenALandmineGame();
            givenALifeIsPlacedOnTheBoardAtXAndYEquals0();

            thenThePlayersLivesIsEqualTo3();

            whenUpdateGameIsCalled();

            thenThePlayersLivesIsEqualTo4();
        }
    }
}
