using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;
using RockPaperScissorsMvc.Models;

namespace RockPaperScissorsMvc.Controllers
{
	public class GameController : Controller
	{
		private readonly ILogger<GameController> _logger;

		private readonly IRpsGame _rpsGame;
		//create a constructor into which i'll inject the business layer.
		public GameController(IRpsGame rpsGame, ILogger<GameController> logger)
		{
			this._rpsGame = rpsGame;
			this._logger = logger;
		}

		// GET: GameController
		public ActionResult Index()
		{
			//Console.WriteLine("Mark is the best!");

			//you'll be getting this data from the business layer
			Player p = new Player()
			{
				Fname = "Thwury",
				Lname = "Thwarthurus"
			};
			return View(p);
		}

		// GET: GameController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: GameController/Create - sthis is conventional routing.
		public ActionResult Create()
		{
			_logger.LogInformation("\n\nINFORMATION - We are in the Create Method - Weeeeee!\n\n");
			_logger.LogError("\n\nERROR - We are in the Create Method - Weeeeee!\n\n");
			//_logger.LogDebug("\n\nERROR - We are in the Create Method - Weeeeee!\n\n");
			return View("CreatePlayer");
		}

		// GET: GameController/Create
		[HttpPost]
		//[Route("CreatePlayer")]// this is attribute routing.
		public ActionResult CreatePlayer(PlayerDerivedClass p)//model binding system takes the dat from the form and matches it to the props of the model.
		{
			//check that the model binding worked.
			if (!ModelState.IsValid)
			{
				RedirectToAction("Create");
			}
			return View("VerifyCreatePlayer", p);
		}

		//[HttpGet]
		public async Task<ActionResult> CreateNewPlayer(PlayerDerivedClass p)
		{
			//check that the model binding worked.
			if (!ModelState.IsValid)
			{
				RedirectToAction("Create");
			}

			// injecting the interface allows you to Mock the implementation in the testing suite.
			bool myBool = await _rpsGame.RegisterPlayerAsync(p);

			if (myBool)
			{
				ViewBag.Welcome = "Hey guy, welcome to R-P-S!";
				return View("LoggedInLandingPage");
			}
			else
			{
				ViewBag.ErrorText = "Hey guy, there was an error!";
				return View("Error");
			}
		}

		public async Task<ActionResult> PlayerList()
		{
			List<PlayerDerivedClass> playerList = await _rpsGame.PlayerListAsync();
			return View(playerList);
		}

		// POST: GameController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: GameController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: GameController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: GameController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: GameController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
