using System;

namespace RockPaperScissors1
{
    public class PlayerDerivedClass : PersonBaseClass
    {
        //private string _state;
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        private int myAge;
        public int MyAge
        {
            get
            {
                return this.myAge;
            }
            set
            {
                if (value > 125 || value < 1)
                {
                    throw new InvalidOperationException("that age value is too high.");
                }
            }
        }

        public PlayerDerivedClass() : base()
        {
            // this.fname = "derivedCLassfname";
            // this.lname = "derivedClasslname";
        }

        //I must create all overload constructors in derived classes
        public PlayerDerivedClass(string fname, string lname, int age = 0) : base(fname, lname)
        {
            // this.fname = fname;
            // this.lname = lname;
            this.MyAge = age;
        }

        public override string GetFullAddress()
        {
            string fullAddy = $"{Fname} {Lname}\n{Street}\n{City}, {State}.";

            return fullAddy;
        }



    }
}