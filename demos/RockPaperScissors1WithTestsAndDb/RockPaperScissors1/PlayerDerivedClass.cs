using System;

namespace RockPaperScissors1
{
    public class PlayerDerivedClass : PersonBaseClass
    {
        //private string _state;
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        private int _myAge;
        public int MyAge
        {
            get
            {
                return this._myAge;
            }
            set
            {
                if (value < 125 || value > 0)
                {
                    _myAge = 0;
                }
            }
        }

        public PlayerDerivedClass() : base() { }

        //I must create all overload constructors in derived classes
        public PlayerDerivedClass(string fname, string lname, int age = 0) : base(fname, lname)
        {
            this.MyAge = age;
        }

        public override string GetFullAddress()
        {
            string fullAddy = $"{Fname} {Lname}\n{Street}\n{City}, {State}.";

            return fullAddy;
        }



    }
}