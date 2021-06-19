﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using RepositoryLayer;

namespace BusinessLayer
{
	public class RpsGame : IRpsGame
	{

		private readonly RpsGameDb _context;
		// create constructors.
		//first register the context in startup.cs
		public RpsGame(RpsGameDb context)
		{
			this._context = context;
		}

		/// <summary>
		/// Saves a new player ot the Db. If un successful, returns false, otherwise TRUE.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public async Task<bool> RegisterPlayerAsync(PlayerDerivedClass p)
		{
			//create a try/catch to save the player
			await _context.Players.AddAsync(p);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
				return false;
			}
			catch (DbUpdateException ex)
			{       //change this to logging
				Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
				return false;
			}
			return true;
		}

		public async Task<List<PlayerDerivedClass>> PlayerListAsync()
		{
			List<PlayerDerivedClass> ps = null;
			try
			{
				ps = _context.Players.ToList();
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine($"There was a problem gettign the players list");
			}
			return ps;
		}
	}
}