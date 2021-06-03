using System;

namespace RockPaperScissors1
{
    public class RpsGame
    {
        public string WelcomeMessage()
        {
            string welcome = "\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.";
            return welcome;
        }

        public string getPlayerName(string playerInput)
        {
            //Console.WriteLine(playerInput);
            playerInput = playerInput.Trim();
            if (playerInput.Length > 20 || playerInput.Length < 1)
            {
                return null;
            }
            return playerInput;
        }

    }
}