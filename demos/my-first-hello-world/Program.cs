using System;

namespace my_first_hello_world
{
    class Program
    {
        static int myNum1 = 5;
        static void Main(string[] args)
        {
            //an interesting way to show comparison adn assignment with if()
            bool b1 = 1 < 0;
            bool b2 = !(12 % 3 > 2);
            if (b1 = b2)
                Console.Write("true: ");
            else
                Console.Write("false: ");
            Console.WriteLine("b1 is {0}.  b2 is {1}.", b1, b2);

            bool b11 = 1 < 0;
            bool b22 = !(12 % 3 > 2);
            if (b1 = b2)
                Console.Write("true: ");
            else
                Console.Write("false: ");
            Console.WriteLine("b1 is {0}.  b2 is {1}.", b11, b22);

            Console.WriteLine("What's that. It's so cringe!");
            string myString = Console.ReadLine();
            Console.WriteLine(myString.ToUpper());
            Console.WriteLine(myString.Length);

            int myNum = 15;
            Console.Write("\t{0} {1}\n", myNum, myNum);

            Console.WriteLine($"This is string interpolation! The number is {myNum1}");

            //this is a comment

            /* this is a multiline comment
            going on 
            and and on*/

            /*
            1. Clone your P0 repo.
            2. create a new feature branch
            3. create the template hello world program in a file.
            4. In that hello world program, add code to....
            5. 1. prompt the user for their age
            6. prompt the user for their name
            7. print the users name and age to the console using string interpolation.
            */
        }
    }
}
