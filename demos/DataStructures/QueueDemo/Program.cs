using System;

namespace QueueDemo
{
    internal class MyQueue
    {
        // variables
        // private string[] myQueue;
        public string[] myQueue { get; set; }
        private int size = 5;
        private int first = 0;// denotes where the first guy is
        private int last = -1;// starts at -1 because when enqueing, the laste get sincremented before accessing the array


        // constructor
        public MyQueue()
        {
            this.myQueue = new string[this.size];
        }

        // methods
        internal string Enqueue(string name)
        {
            // 1. implement the check here
            // here check the value of last to make sure I'm not about to add something to unalocated memeory.
            // if I'm at the end of the array, call Reallocate();
            this.myQueue[++last] = name;
            return this.myQueue[last];
        }

        internal string Dequeue()
        {
            return this.myQueue[first++];
        }

        internal string Peek()
        {
            return this.myQueue[first];
        }

        private void Reallocate()
        {
            // 2. implemente reallocation to a bigger array (when needed)
            // this will double the size of the array.
        }

        // 3. implement a circular array.
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyQueue myQueue = new MyQueue();

            // Enqueue a few
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Mark")}");
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Arely")}");
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Ethan")}");

            // peek a boo 
            System.Console.WriteLine($"{myQueue.Peek()} is on first in line");// should be Mark

            //Dequeue a few
            System.Console.WriteLine($"Dequeueing {myQueue.Dequeue()}");// dequeue Mark


            // peek a boo 
            System.Console.WriteLine($"{myQueue.Peek()} is first in line");// Arely

            // add to many and you crash
            // System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Mark")}");
            // System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Arely")}");
            // System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Ethan")}");


        }
    }
}
