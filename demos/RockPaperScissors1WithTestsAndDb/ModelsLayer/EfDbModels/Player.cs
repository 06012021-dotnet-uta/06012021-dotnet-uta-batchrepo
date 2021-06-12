using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Player
    {
        public Player()
        {
            GameGameWinnerNavigations = new HashSet<Game>();
            GamePlayer1Navigations = new HashSet<Game>();
            GamePlayer2Navigations = new HashSet<Game>();
        }

        public int PlayerId { get; set; }
        public string PlayerFname { get; set; }
        public string PlayerLname { get; set; }
        public int? PlayerAge { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? TestValue { get; set; }

        public virtual ICollection<Game> GameGameWinnerNavigations { get; set; }
        public virtual ICollection<Game> GamePlayer1Navigations { get; set; }
        public virtual ICollection<Game> GamePlayer2Navigations { get; set; }
    }
}
