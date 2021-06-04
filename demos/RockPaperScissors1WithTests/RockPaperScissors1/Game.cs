using System.Collections.Generic;

namespace RockPaperScissors1
{
    public class Game
    {
        public PlayerDerivedClass Player1 { get; set; }//user
        public PlayerDerivedClass Player2 { get; set; }// computer
        public List<int> Player1RoundChoices { get; set; }//all the choices that the user makes during the game
        public List<int> Computer2RoundChoices { get; set; }//all the choices that the computer makes during the game

        public Game()
        {
            Player1RoundChoices = new List<int>();
            Computer2RoundChoices = new List<int>();
        }
    }
}