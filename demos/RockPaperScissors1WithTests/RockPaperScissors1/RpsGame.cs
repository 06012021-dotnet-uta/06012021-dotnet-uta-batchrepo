using System;

namespace RockPaperScissors1
{
    public class RpsGame : IRpsGame
    {
        Random rand = new Random();

        public string WelcomeMessage()
        {
            string welcome = "\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.";
            return welcome;
        }

        /// <summary>
        /// this method will take the input from the user and verify that it is not null and not more that 20 chars
        /// </summary>
        /// <param name="playerInput"></param>
        /// <returns></returns>
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

        public bool GetUsersChoice(string playerChoice, out int playerChoiceInt)
        {
            int pci;
            //create a int variable to catch the converted choice.
            bool result = Int32.TryParse(playerChoice, out pci);
            playerChoiceInt = pci;
            if (!result)
            {
                return false;
            }
            return result;
        }
        /// <summary>
        /// this method gets the computers choice of rock,paper, or scissors
        /// </summary>
        /// <returns></returns>
        public int GetComputerChoice()
        {
            //get a random number 1,2, or 3.
            int computerChoice = rand.Next(1, Enum.GetNames(typeof(RpsChoice)).Length + 1);
            return computerChoice;
        }

        /// <summary>
        /// This method takes the in RpsChoiceEnums for the players choices and evaluates them to see who won the round
        /// </summary>
        /// <param name="playerChoiceInt"></param>
        /// <param name="computerChoice"></param>
        /// <returns></returns>
        public int EvaluteRoundWinner(int playerChoiceInt, int computerChoice)
        {
            if ((playerChoiceInt == 1 && computerChoice == 2) ||
                 (playerChoiceInt == 2 && computerChoice == 3) ||
                 (playerChoiceInt == 3 && computerChoice == 1))
                return 2;
            else if (playerChoiceInt == computerChoice)
                return 0;
            else
                return 1;
        }

        /// <summary>
        /// method to calculate the winner
        ///to be called after each round 
        /// it will compare the List<int>'s
        /// 0 == no winner yet
        /// 1 == player1 wins
        /// 2 == computer wins
        /// </summary>
        public int CalculateWinner(Game g)
        {
            int p1Wins = 0;
            int cpWins = 0;
            for (int x = 0; x < g.Player1RoundChoices.Count; x++)
            {
                int result = this.EvaluteRoundWinner(g.Player1RoundChoices[x], g.Computer2RoundChoices[x]);
                switch (result)
                {
                    case 0:
                        break;
                    case 1:
                        p1Wins++;
                        break;
                    case 2:
                        cpWins++;
                        break;
                    default:
                        Console.WriteLine("There was a problem with the round evaluation");
                        break;
                }
            }
            if (p1Wins == 2)
                return 1;
            else if (cpWins == 2)
                return 2;
            return 0;
        }

        public int DoSomething()
        {
            int x = 5;
            int y = 6;
            int z = x + y;
            return z;
        }

        //cant (as far as I know) test private methods
        private int privateMethodTest()
        {
            return 5;
        }
    }//end of class
}// end of namespace