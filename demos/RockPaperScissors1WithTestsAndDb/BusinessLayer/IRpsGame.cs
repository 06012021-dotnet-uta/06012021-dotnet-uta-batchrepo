using GameModels;

namespace BusinessLayer
{
    public interface IRpsGame
    {
        string WelcomeMessage();
        string getPlayerName(string x);
        bool GetUsersChoice(string x, out int y);
        int GetComputerChoice();
        int EvaluteRoundWinner(int x, int y);
        int CalculateWinner(GameModel g);
        // int privateMethodTest();
    }
}