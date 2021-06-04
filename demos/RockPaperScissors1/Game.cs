using System.Collections.Generic;

namespace RockPaperScissors1
{
    public class Game
    {
        public PlayerDerivedClass Player1 { get; set; }
        public PlayerDerivedClass Player2 { get; set; }
        public List<int> Player1RoundChoices { get; set; }
        public List<int> Computer2RoundChoices { get; set; }

        public Game()
        {
            Player1RoundChoices = new List<int>();
            Computer2RoundChoices = new List<int>();
        }


    }
}