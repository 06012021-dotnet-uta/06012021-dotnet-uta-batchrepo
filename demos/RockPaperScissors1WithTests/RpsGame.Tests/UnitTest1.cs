using System;
using Xunit;
using RockPaperScissors1;


namespace RpsGame.Tests
{
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
            IRpsGame game = new RockPaperScissors1.RpsGame();

            //Act
            string welcomeMessageTest = game.WelcomeMessage();

            //Assert
            Assert.Equal("\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.", welcomeMessageTest);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 1)]
        public void EvaluteRoundWinnerRetunsCorrectWinner(int a, int b)
        {
            //Arrange
            IRpsGame game = new RockPaperScissors1.RpsGame();

            //Act
            int result = game.EvaluteRoundWinner(a, b);

            //Assert
            Assert.Equal(2, result);

        }
    }//end of class
}// end of namespace
