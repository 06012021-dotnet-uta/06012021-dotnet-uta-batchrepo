namespace RockPaperScissors1
{
    public interface IRpsGame
    {
        string WelcomeMessage();
        string getPlayerName(string x);
        bool GetUsersChoice(string x, out int y);
        int GetComputerChoice();
        int EvaluteRoundWinner(int x, int y);
        int CalculateWinner(Game g);
        // int privateMethodTest();
    }
}