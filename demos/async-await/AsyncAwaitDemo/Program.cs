using System;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncMethodsClass amc = new AsyncMethodsClass();

            // System.Console.WriteLine($"Program starting");

            // string method1 = await amc.Method1();
            // System.Console.WriteLine($"method1 returned {method1}\n");
            // int method2 = await amc.Method2();
            // System.Console.WriteLine($"method2 returned {method2}\n");

            // int method3 = await amc.Method3();
            // System.Console.WriteLine($"method3 returned {method3}\n");

            // Person method4 = await amc.Method4();
            // System.Console.WriteLine($"method4 returned {method4.Fname}, age {method4.Age}\n");

            System.Console.WriteLine($"Program starting");

            Task<string> method1 = amc.Method1();
            Task<int> method2 = amc.Method2();
            Task<int> method3 = amc.Method3();
            Task<Person> method4 = amc.Method4();

            int method2result = await method2;
            System.Console.WriteLine($"method2 returned {method2result}\n");

            int method3result = await method3;
            System.Console.WriteLine($"method3 returned {method3result}\n");

            Person method4result = await method4;
            System.Console.WriteLine($"method4 returned {method4result.Fname}, age {method4result.Age}\n");

            string method1result = await method1;
            System.Console.WriteLine($"method1 returned {method1result}\n");
        }
    }
}
