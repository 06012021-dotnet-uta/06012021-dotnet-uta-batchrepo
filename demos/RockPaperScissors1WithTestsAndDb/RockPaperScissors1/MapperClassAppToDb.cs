using RpsDbContext;

namespace RockPaperScissors1
{
    public static class MapperClassAppToDb
    {
        public static Player AppPlayerToDbPlayer(PlayerDerivedClass playerDerivedClass)
        {
            //create a Db player
            Player p = new Player()
            {
                PlayerFname = playerDerivedClass.Fname,
                PlayerLname = playerDerivedClass.Lname,
                PlayerAge = playerDerivedClass.MyAge,
                Street = playerDerivedClass.Street,
                City = playerDerivedClass.City,
                Country = playerDerivedClass.MyCountry,
                State = playerDerivedClass.State,
            };
            return p;
        }

        public static RpsDbContext.Game AppGameToDbGame(Game game, int p1, int p2)
        {
            RpsDbContext.Game g = new RpsDbContext.Game()
            {
                Player1 = p1,
                Player2 = p2,
                GameWinner =

            };
        }
    }
}