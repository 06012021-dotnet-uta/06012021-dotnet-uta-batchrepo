using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer;
using ModelsLibrary;

namespace RpsGame.Tests
{
    public class MockRpsGame : IRpsGame
    {
        public Task<List<PlayerDerivedClass>> PlayerListAsync()
        {
            // implement a mock body to return a determined result.
            PlayerDerivedClass mockPlayer1 = new PlayerDerivedClass()
            {
                City = "mycity",
                Fname = "mark",
                Lname = "moore",
                MyAge = 12,
                MyCountry = "usa",
                PersonId = 100,
                State = "tx",
                Street = "123 main"
            };
            PlayerDerivedClass mockPlayer2 = new PlayerDerivedClass()
            {
                City = "yourcity",
                Fname = "Jenny",
                Lname = "FromThaBlock",
                MyAge = 18,
                MyCountry = "Cali",
                PersonId = 101,
                State = "California",
                Street = "8675309 S. Main St."
            };

            List<PlayerDerivedClass> mockList = new List<PlayerDerivedClass>();
            mockList.Add(mockPlayer1);
            mockList.Add(mockPlayer2);

            return Task.FromResult(mockList);
        }

        public Task<PlayerDerivedClass> RegisterPlayerAsync(PlayerDerivedClass p)
        {
            PlayerDerivedClass mockPlayer2 = new PlayerDerivedClass()
            {
                City = "yourcity",
                Fname = "Jenny",
                Lname = "FromThaBlock",
                MyAge = 18,
                MyCountry = "Cali",
                PersonId = 101,
                State = "California",
                Street = "8675309 S. Main St."
            };

            return Task.FromResult(mockPlayer2);
        }
    }
}