using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Game
    {
        public Game()
        {
            Rounds = new HashSet<Round>();
        }

        public int GameId { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int GameWinner { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual Player GameWinnerNavigation { get; set; }
        public virtual Player Player1Navigation { get; set; }
        public virtual Player Player2Navigation { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
    }
}
