using System;

namespace RockPaperScissors1
{
    partial class Program
    {

        static void Main(string[] args)
        {

            // PersonBaseClass personBaseClass1 = new PersonBaseClass();
            // PersonBaseClass personBaseClass2 = new PersonBaseClass("Mark", "Moore");
            // personBaseClass2.fname = "Jimmy";
            //personBaseClass2.lname = Console.ReadLine();

            // Console.WriteLine($"{personBaseClass1.fname} {personBaseClass1.lname} is default");
            // Console.WriteLine($"{personBaseClass2.fname} {personBaseClass2.lname} is what I sent");

            // PlayerDerivedClass playerDerivedClass1 = new PlayerDerivedClass();
            // PlayerDerivedClass playerDerivedClass2 = new PlayerDerivedClass("", "");

            //Console.WriteLine($"{playerDerivedClass1.fname} {playerDerivedClass1.lname} is default of PlayerDerivedClass");
            // playerDerivedClass1.MyCountry = "'Merca";
            //Console.WriteLine($"My country is => {playerDerivedClass1.MyCountry}");
            // playerDerivedClass1.MyAge = 2;
            //Console.WriteLine(playerDerivedClass1.MyAge);
            //PlayerDerivedClass playerDerivedClass2 = new PlayerDerivedClass("", "");
            // playerDerivedClass1.City = "Crowley";
            // playerDerivedClass1.State = "Texas";
            // playerDerivedClass1.Street = "123 Main St.";
            // playerDerivedClass1.fname = "Mark";
            // playerDerivedClass1.lname = "Moore";

            // string fullAddress = playerDerivedClass1.GetFullAddress();
            // Console.WriteLine(fullAddress);





            //Console.WriteLine("\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.");
            RpsGame rpsGame = new RpsGame();
            PlayerDerivedClass player1 = new PlayerDerivedClass();
            PlayerDerivedClass computer = new PlayerDerivedClass("Max", "HeadRoom", 38);
            Console.WriteLine(rpsGame.WelcomeMessage());
            bool successfulConversion = false;
            int playerChoiceInt;
            string quitter = "n";

            //get players info
            Console.WriteLine("Please enter your first name");
            player1.Fname = rpsGame.getPlayerName(Console.ReadLine());
            if (player1.Fname == null)
            {
                Console.WriteLine("\n\nreturned null\n\n");
            }
            Console.WriteLine($"Whatsa haps, {player1.Fname}? Please enter your last name");
            player1.Lname = rpsGame.getPlayerName(Console.ReadLine());
            Console.WriteLine($"Welcome to the gameZone, {player1.Fname} {player1.Lname}.");

            //play the game
            do
            {
                //start first to 2 wins game here
                int computerRoundWins = 0;
                int playerRoundWins = 0;
                int tieRounds = 0;
                while (computerRoundWins < 2 && playerRoundWins < 2)
                {
                    //a do/while loop runs at least once, while a while loop may not ever run.
                    //gets the players choice
                    do
                    {
                        Console.WriteLine("1. Rock\n2. Paper\n3.Scissors");
                        string playerChoice = Console.ReadLine();

                        //create a int variable to catch the converted choice.
                        successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                        //check if the user inputted a number but the numebr is out of bounds.
                        if (playerChoiceInt > 3 || playerChoiceInt < 1)
                            Console.WriteLine($"You inputted {playerChoiceInt}. That is not a valid choice.");
                        else if (!successfulConversion)
                            Console.WriteLine($"You inputted {playerChoice}. That is not a valid choice.");

                    } //while (!successfulConversion || (playerChoiceInt < 1 || playerChoiceInt > 3));
                    while (!successfulConversion || !(playerChoiceInt > 0 && playerChoiceInt < 4));//both of hte above are valid.

                    //you can omit the {} if the body of hte statement is only 1 line or even put it all on one line.
                    // if (successfulConversion == true) Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {playerChoiceInt}");
                    // else
                    //     Console.WriteLine($"the conversion returned {successfulConversion} and the player chose {playerChoiceInt}");

                    //get a random number generator object from the Random Class
                    Random rand = new Random();
                    //get a random number 1,2, or 3.
                    int computerChoice = rand.Next(1, Enum.GetNames(typeof(RpsChoice)).Length + 1);

                    //print the choices.
                    Console.WriteLine($"{player1}'s choice is {(RpsChoice)playerChoiceInt}");
                    Console.WriteLine($"the computers choice is {(RpsChoice)computerChoice}");

                    //check who won.
                    if ((playerChoiceInt == 1 && computerChoice == 2) ||
                         (playerChoiceInt == 2 && computerChoice == 3) ||
                         (playerChoiceInt == 3 && computerChoice == 1))
                    {
                        Console.WriteLine("Computer Wins this round");
                        // computerRoundWins++;
                        computerRoundWins = computerRoundWins + 1;
                    }
                    else if (playerChoiceInt == computerChoice)
                    {
                        Console.WriteLine("Tie Round!!");
                        tieRounds++;
                    }
                    else
                    {
                        Console.WriteLine($"{player1} wins this round!!!");
                        playerRoundWins++;
                    }

                    //you can get typeDef the number to the equivalent RpsChoice Enum.
                    // Console.WriteLine((RpsChoice)playerChoiceInt);
                    // Console.WriteLine((RpsChoice)computerChoice);

                }//end of rounds

                if (computerRoundWins == 2)
                {
                    Console.WriteLine($"\n\tIt looks like the computer won this game. Better luck next time!\n");
                }
                else if (playerRoundWins == 2)
                {
                    Console.WriteLine($"\n\tYou did it! You won against the computer!\n");
                }

                //see if the player wants to play again
                do
                {
                    Console.WriteLine($"Hey, {player1}. Would you like to play again?\n I'll keep asking till you answer me!!\n enter Y or N");
                    quitter = Console.ReadLine();
                    quitter = quitter.Trim().ToLower();
                    //Console.WriteLine($"The choice to play or not is => {quitter}");
                } //while (quitter.CompareTo("y") != 0 && quitter.CompareTo("n") != 0);
                while (quitter != "y" && quitter != "n");

            } while (quitter == "y");

            /*Coding challenge
            1. implement a loop to play again if the player chooses to.
            2. get the players name to print out the winners names
            3. implement the code to play 3 rounds.
            */

        }//end of main
    }//end of class
}//end of namespace
