using System;

namespace RockPaperScissors1
{
    public class Program
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
            string quitter = "n";

            do
            {
                //Console.WriteLine("\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.");
                RpsGame rpsGame = new RpsGame();//create the game.
                PlayerDerivedClass player1 = new PlayerDerivedClass();//create an empty class for the player
                PlayerDerivedClass computer = new PlayerDerivedClass("Max", "HeadRoom", 38);// create the computer
                Game game = new Game();
                game.Player1 = player1;
                game.Player2 = computer;

                //welcome players and set up the game
                Console.WriteLine(rpsGame.WelcomeMessage());
                bool successfulConversion = false;
                int playerChoiceInt;
                string fn = null;

                //get players info

                do
                {
                    Console.WriteLine("Please enter your first name");
                    fn = rpsGame.getPlayerName(Console.ReadLine());
                } while (fn == null);
                game.Player1.Fname = fn;//set the first name

                do
                {
                    Console.WriteLine($"Whatsa haps, {game.Player1.Fname}? Please enter your last name");
                    fn = rpsGame.getPlayerName(Console.ReadLine());
                } while (fn == null);
                game.Player1.Lname = fn; //set the users last name

                Console.WriteLine($"Welcome to the gameZone, {game.Player1.Fname} {game.Player1.Lname}.");

                //play the game
                //start first to 2 wins game here
                // int computerRoundWins = 0;
                // int playerRoundWins = 0;
                // int tieRounds = 0;
                while (rpsGame.CalculateWinner(game) == 0)
                {
                    //a do/while loop runs at least once, while a while loop may not ever run.
                    //gets the players choice
                    do
                    {
                        Console.WriteLine("1. Rock\n2. Paper\n3.Scissors");
                        successfulConversion = rpsGame.GetUsersChoice(Console.ReadLine(), out playerChoiceInt);
                        if (!successfulConversion)
                            Console.WriteLine($"That is not a valid choice.");
                    } while (!successfulConversion || !(playerChoiceInt > 0 && playerChoiceInt < 4));

                    //get the computers choice and assign player1's choice too
                    game.Computer2RoundChoices.Add(rpsGame.GetComputerChoice());
                    game.Player1RoundChoices.Add(playerChoiceInt);

                    //print the choices.
                    Console.WriteLine($"{game.Player1.Fname} {game.Player1.Lname}'s choice is {(RpsChoice)game.Player1RoundChoices[game.Player1RoundChoices.Count - 1]}");
                    Console.WriteLine($"{game.Player2.Fname} {game.Player2.Lname}'s choice is {(RpsChoice)game.Computer2RoundChoices[game.Computer2RoundChoices.Count - 1]}");

                    //check who won.
                    int roundWinner = rpsGame.EvaluteRoundWinner(game.Player1RoundChoices[game.Player1RoundChoices.Count - 1], game.Computer2RoundChoices[game.Computer2RoundChoices.Count - 1]);
                    switch (roundWinner)
                    {
                        case 0:
                            Console.WriteLine("This was a tie round");
                            break;
                        case 1:
                            Console.WriteLine($"This round was won by {game.Player1.Fname} {game.Player1.Lname}");
                            break;
                        case 2:
                            Console.WriteLine($"This round was won by {game.Player2.Fname} {game.Player2.Lname}");
                            break;
                        default:
                            Console.WriteLine("There was a problem with the round evaluation");
                            break;
                    }
                }//end of rounds
                int winner = rpsGame.CalculateWinner(game);
                if (winner == 2)
                    Console.WriteLine($"\n\tIt looks like the computer won this game. Better luck next time!\n");
                else if (winner == 1)
                    Console.WriteLine($"\n\tYou did it! You won against the computer!\n");

                do//see if the player wants to play again
                {
                    Console.WriteLine($"Hey, {game.Player1.Fname} {game.Player1.Lname}. Would you like to play again?\n I'll keep asking till you answer me!!\n enter Y or N");
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
