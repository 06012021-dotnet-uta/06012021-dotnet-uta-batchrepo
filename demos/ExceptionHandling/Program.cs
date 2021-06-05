using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int five = 5;
            int zero = 0;
            for (int x = 0; x < 5; x++)
            {
                try
                {
                    int a = five / x;
                }
                catch (ApplicationException)
                {
                    Console.WriteLine("this is the applicaiton exception");
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine($"This is the arithmetic exception => {ex.InnerException.ToString()}");
                }
                catch (Exception)
                {
                    Console.WriteLine($"this is the Base class Exception.");
                }
                finally
                {
                    Console.WriteLine("\nthis is the finally block\n");
                    if (zero == 0)
                    {
                        zero = 5;
                    }
                    else if (zero == 5)
                    {
                        zero = 0;
                    }
                }

            }




        }//main
    }//class
}//namespace
