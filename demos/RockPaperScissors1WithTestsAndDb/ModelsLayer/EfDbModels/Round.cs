using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Round
    {
        public int RoundId { get; set; }
        public int Player1Choice { get; set; }
        public int Player2Choice { get; set; }
        public int GameId { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual Game Game { get; set; }
        public virtual Choice Player1ChoiceNavigation { get; set; }
        public virtual Choice Player2ChoiceNavigation { get; set; }
    }
}
