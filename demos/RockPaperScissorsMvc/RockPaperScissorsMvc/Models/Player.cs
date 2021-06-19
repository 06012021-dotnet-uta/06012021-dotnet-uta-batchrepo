using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsMvc.Models
{
	public class Player
	{
		[Required(ErrorMessage = "The Fname is required")]
		[MinLength(5, ErrorMessage = "THis is the custom error message")]
		public string Fname { get; set; }
		public string Lname { get; set; }
	}
}
