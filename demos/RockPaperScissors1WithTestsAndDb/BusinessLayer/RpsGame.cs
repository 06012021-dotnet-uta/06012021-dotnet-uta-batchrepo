using System;
using System.Linq;
using RpsDbContext;
using GameModels;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class RpsGame : IRpsGame
	{
		Random rand = new Random();
		private RpsGameDbContext _context;


		public RpsGame()
		{
			this._context = new RpsGameDbContext();
		}

		//public void MyFunction(string name)
		//{
		//	foreach (Player c in Players)
		//	{
		//		if (c.PlayerFirstName == name)
		//		{
		//			return c;
		//		}
		//	}
		//}

		//foreach (var p in players)
		//{
		//	Console.WriteLine($"the choice is {p.PlayerFname} {p.PlayerLname}, {p.City} {p.Street} {p.State}");
		//}

		public string WelcomeMessage()
		{
			// here you can use the context because it's inside of a method.
			//Notice the type of the returned Player is the Model created by EFCore.
			// You may need to map this model to the locally created one or to a ViewModel.
			var players = _context.Players.Where(x => x.PlayerFname == "Mark").FirstOrDefault();
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
		public int CalculateWinner(GameModel g)
		{
			int p1Wins = 0;// count how many times the user has won
			int cpWins = 0;// count how many times the computer has won
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

		public async Task<bool> SaveGame(GameModel game)
		{
			// add the players to the Db First
			//1. map the player to a EF Player Model
			Player p1 = MapperClassAppToDb.AppPlayerToDbPlayer(game.Player1);
			p1.PlayerAge = 10;// must give an age to avoid Exception
			await _context.AddAsync(p1);
			var dbPlayer1 = _context.Players.OrderBy(x => x.DateAdded).Last();//grab the player from the Db
			_context.SaveChanges();

			Player p2 = MapperClassAppToDb.AppPlayerToDbPlayer(game.Player2);
			p2.PlayerAge = 10;
			await _context.AddAsync(p2);
			_context.SaveChanges();
			var dbPlayer2 = _context.Players.OrderBy(x => x.DateAdded).Last();//grab the player from the Db
																			  //_context.SaveChanges();

			// add the Game to the Db
			RpsDbContext.Game g = MapperClassAppToDb.AppGameToDbGame(game, dbPlayer1.PlayerId, dbPlayer2.PlayerId);

			// get the game winner by sending in the original game
			int winner = CalculateWinner(game);
			if (winner == 1) g.GameWinner = dbPlayer1.PlayerId;// add users id as winner
			if (winner == 2) g.GameWinner = dbPlayer2.PlayerId;// add computer as winner

			await _context.AddAsync(g);
			//add the rounds to the Db
			//get the game Id
			Game g1 = _context.Games.OrderBy(x => x.DateAdded).Last();
			for (int x = 0; x < game.Player1RoundChoices.Count; x++)
			{
				Round r = new Round()
				{
					GameId = g1.GameId,
					Player1Choice = game.Player1RoundChoices[x],
					Player2Choice = game.Computer2RoundChoices[x],
				};
				await _context.AddAsync(r);
			}
			await _context.SaveChangesAsync();

			return true;
		}
	}
}