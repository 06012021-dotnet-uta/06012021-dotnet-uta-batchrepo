using System;
using Xunit;
using RockPaperScissors1;
using BusinessLayer;
using GameModels;

namespace RpsGame.Tests
{
    public class MockRpsGame : IRpsGame
    {
        public int CalculateWinner(GameModel g)
        {
            throw new NotImplementedException();
        }

        public int EvaluteRoundWinner(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int GetComputerChoice()
        {
            throw new NotImplementedException();
        }

        public string getPlayerName(string x)
        {
            throw new NotImplementedException();
        }

        public bool GetUsersChoice(string x, out int y)
        {
            throw new NotImplementedException();
        }

        public string WelcomeMessage()
        {
            return "Congrats you successfully called the method";
        }
    }


    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int x = 5;
            int y = 6;

            //Act
            int z = x + y;

            //Assert
            Assert.Equal(11, z);
        }

        [Fact]
        public void WelcomeMessageReturnsCorrectMessage()
        {
            //Arrange
            // mock the RpsGame class toisolate the method I want to test and substitute en expected return
            IRpsGame game = new MockRpsGame();

            //Act
            string welcomeMessageTest = game.WelcomeMessage();

            //Assert
            Assert.Equal("Congrats you successfully called the method", welcomeMessageTest);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 1)]
        public void EvaluteRoundWinnerRetunsCorrectWinner(int a, int b)
        {
            //Arrange
            IRpsGame game = new BusinessLayer.RpsGame();

            //Act
            int result = game.EvaluteRoundWinner(a, b);

            //Assert
            Assert.Equal(2, result);

        }
        [Fact]
        public void nextTest()
        {

        }
    }//end of class
}// end of namespace
