using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Choice
    {
        public Choice()
        {
            RoundPlayer1ChoiceNavigations = new HashSet<Round>();
            RoundPlayer2ChoiceNavigations = new HashSet<Round>();
        }

        public int ChoiceId { get; set; }
        public string ChoiceValue { get; set; }

        public virtual ICollection<Round> RoundPlayer1ChoiceNavigations { get; set; }
        public virtual ICollection<Round> RoundPlayer2ChoiceNavigations { get; set; }
    }
}
