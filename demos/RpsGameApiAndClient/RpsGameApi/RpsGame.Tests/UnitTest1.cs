using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using RepositoryLayer;
using RpsGameApi.Controllers;
using Xunit;
using FluentAssertions;
//you can give the page an alias to differentiate between ambiguously named duos.
using BRpsGame = BusinessLayer.RpsGame;

namespace RpsGame.Tests
{

	public class UnitTest1
	{
		//create the in-memory Db //  installed EF Core
		DbContextOptions<RpsGameDb> options = new DbContextOptionsBuilder<RpsGameDb>()
	.UseInMemoryDatabase(databaseName: "TestingDb")
	.Options;

		[Fact]
		public async Task RegisterPlayerInsertsPlayerCorrectly()
		{
			// arrange
			//createa a player to inset into the inmemory db.
			PlayerDerivedClass pdc = new PlayerDerivedClass()
			{
				City = "city",
				Fname = "Fname",
				Lname = "Lname",
				MyAge = 1,
				MyCountry = "Canada",
				State = "Oklahoma",
				Street = "321 niam"
			};
			PlayerDerivedClass pdc12;
			PlayerDerivedClass pdc1;

			using (var context = new RpsGameDb(options))
			{
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.
				context.Players.Add(pdc);
				context.SaveChanges();
				pdc1 = context.Players.Where(x => x.Fname == "Fname").FirstOrDefault();
			}

			// act
			// add to the In-Memory Db
			//instantiate the inmemory db
			using (var context = new RpsGameDb(options))
			{
				//verify that the db was deleted and created anew
				context.Database.EnsureDeleted();// delete any Db fro a previous test
				context.Database.EnsureCreated();// create anew the Db... you will need ot seed it again.

				//instantiate the RpsGameClass that we are going to unit test
				BRpsGame rpsGame = new BRpsGame(context);
				pdc12 = await rpsGame.RegisterPlayerAsync(pdc);

				context.SaveChanges();
				//}

				//assert
				// verify the the result was as expected
				//using (var context = new RpsGameDb(options))
				//{
				int amt = await context.Players.CountAsync();
				pdc.PersonId = 1;
				var p = context.Players.Where(x => x.Fname == "Fname").FirstOrDefault();
				//Assert.True(result);
				Assert.Equal(1, amt);
				Assert.NotNull(p);
				Assert.Contains(pdc1, context.Players);
				Assert.Equal(pdc1, p);

			}
		}


		//make a test that will isolate a controller method to test specifically it's functionality
		[Fact]
		public async Task PlayerListAsyncReturnsAListOfPlayers()
		{
			//arrange
			//get an instance of my mocked class to inject into the Business layer.
			IRpsGame mockRpsGame = new MockRpsGame();
			RpsGameController controller = new RpsGameController(mockRpsGame);
			PlayerDerivedClass mockPlayer1 = new PlayerDerivedClass()
			{
				City = "mycity",
				Fname = "mark",
				Lname = "moore",
				MyAge = 12,
				MyCountry = "usa",
				PersonId = 100,
				State = "tx",
				Street = "123 main"
			};
			PlayerDerivedClass mockPlayer2 = new PlayerDerivedClass()
			{
				City = "yourcity",
				Fname = "Jenny",
				Lname = "FromThaBlock",
				MyAge = 18,
				MyCountry = "Cali",
				PersonId = 101,
				State = "California",
				Street = "8675309 S. Main St."
			};
			List<PlayerDerivedClass> mockList1 = new List<PlayerDerivedClass>();
			mockList1.Add(mockPlayer1);
			mockList1.Add(mockPlayer2);

			//act
			IEnumerable<PlayerDerivedClass> result = await controller.PlayerList();
			//var result = controller.PlayerList();

			var x = result.Where(x => x.Fname == "Jenny").FirstOrDefault();
			var y = mockList1.Where(x => x.Fname == "Jenny").FirstOrDefault();

			//assert
			// Assert.Equal(mockList1, result);
			// Assert.Equal(y, x);
			//Assert.Equal(y.Fname, x.Fname);
			//Assert.True(result.Equals(mockList1));
			Assert.True(y.Fname.Equals(x.Fname));
		}

		[Fact]
		public async Task RegisterPlayerAsyncReturnsAPlayer()
		{
			//arrange
			IRpsGame mockRpsGame = new MockRpsGame();
			RpsGameController controller = new RpsGameController(mockRpsGame);
			PlayerDerivedClass mockPlayer2 = new PlayerDerivedClass()
			{
				City = "yourcity",
				Fname = "Jenny",
				Lname = "FromThaBlock",
				MyAge = 18,
				MyCountry = "Cali",
				PersonId = 101,
				State = "California",
				Street = "8675309 S. Main St."
			};
			//act
			var result = await controller.CreateNewPlayer(mockPlayer2);
			var result1 = (CreatedResult)result.Result;
			var result2 = result1.Value;

			//assert
			// using FluentAssertions here to evaluate the objects values bc xunit has no such method.
			result2.Should().BeEquivalentTo(mockPlayer2);

		}

	}
}
