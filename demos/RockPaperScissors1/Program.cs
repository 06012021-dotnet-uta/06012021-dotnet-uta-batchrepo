using System;

namespace RockPaperScissors1
{
    class Program
    {
        public enum RpsChoice
        {
            Rock = 1,//equivalent to 0
            Paper = 2,//equivalent to 1
            Scissors = 3//equivalent to 2
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.");
            bool successfulConversion = false;
            int playerChoiceInt;
            do
            {
                Console.WriteLine("1. Rock\n2. Paper\n3.Scissors");
                string playerChoice = Console.ReadLine();

                //create a int variable to catch the converted choice.
                successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                //check if the user inputted a number but the numebr is out of bounds.
                if (playerChoiceInt > 3 || playerChoiceInt < 1)
                {
                    Console.WriteLine($"You inputted {playerChoiceInt}. That is not a valid choice.");
                }
                else if (!successfulConversion)
                {
                    Console.WriteLine($"You inputted {playerChoice}. That is not a valid choice.");
                }

            } //while (!successfulConversion || (playerChoiceInt < 1 || playerChoiceInt > 3));
            while (!successfulConversion || !(playerChoiceInt > 0 && playerChoiceInt < 4));//both of hte above are valid.

            //you can omit the {} if the body of hte statement is only 1 line
            if (successfulConversion == true) Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {playerChoiceInt}");
            else
                Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {playerChoiceInt}");

            //kget a random number generator object
            Random rand = new Random();
            //get a random number 1,2, or 3.
            int computerChoice = rand.Next(1, 4);

            //print the choices.
            Console.WriteLine($"the players choice is {playerChoiceInt}");
            Console.WriteLine($"the computers choice is {computerChoice}");

            //check who won.
            if ((playerChoiceInt == 1 && computerChoice == 2)
                || (playerChoiceInt == 2 && computerChoice == 3)
                || (playerChoiceInt == 3 && computerChoice == 1)) Console.WriteLine("Computer Wins");
            else if (playerChoiceInt == computerChoice) Console.WriteLine("Tie Game!!");
            else Console.WriteLine("Player Wins!!!");
        }
    }
}
