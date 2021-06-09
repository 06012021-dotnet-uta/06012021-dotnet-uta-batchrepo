using System.Threading.Tasks;
using System;

namespace AsyncAwaitDemo
{
    public class AsyncMethodsClass
    {
        public async Task<string> Method1()
        {
            System.Console.WriteLine("Method1 BT");
            Task task = Task.Delay(4000);
            System.Console.WriteLine("Method1 AT");


            // System.Console.WriteLine("Please enter a sentence");
            // string userInput = Console.ReadLine();
            await task;
            System.Console.WriteLine("Method1 AAT");
            return "Mark is da bomb.";
        }

        public async Task<int> Method2()
        {
            System.Console.WriteLine("Method2 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("Method2 AT");

            // System.Console.WriteLine("Please enter a number");
            // int num;
            // int userInput = Int32.TryParse(Console.ReadLine(), out num);
            await task;
            System.Console.WriteLine("Method2 AAT");
            return 1;
        }

        public async Task<int> Method3()
        {
            System.Console.WriteLine("Method3 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("Method3 AT");
            // System.Console.WriteLine("Please enter a number");
            // int num;
            // string userInput = Int32.TryParse(Console.ReadLine(), out num);
            await task;
            System.Console.WriteLine("Method3 AAT");
            return 2;
        }

        public async Task<Person> Method4()
        {
            System.Console.WriteLine("Method4 BT");
            Task task = Task.Delay(3000);
            System.Console.WriteLine("Method4 AT");
            Person p = new Person() { Fname = "Ethan Hawke", Age = 50 };
            await task;
            System.Console.WriteLine("Method4 AAT");
            return p;
        }
    }//EoC
}//EoN