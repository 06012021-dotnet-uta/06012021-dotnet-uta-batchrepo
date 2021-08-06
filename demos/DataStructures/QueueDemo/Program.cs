using System;

namespace QueueDemo
{
    internal class MyQueue
    {
        // variables
        // private string[] myQueue;
        public string[] myQueue { get; set; }
        private int size = 5; // the total number of elements in the array
        private int first = 0;// denotes where the first guy is
        private int last = -1;// starts at -1 because when enqueing, the laste get sincremented before accessing the array
        private int arraySize = 0;

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
            if (last == (size - 1))
            {
                if (this.arraySize == size)
                {
                    this.Reallocate();
                }
                else
                {
                    last = -1;
                }

            }
            this.myQueue[++last] = name;
            this.arraySize++;
            return this.myQueue[last];
        }

        internal string Dequeue()
        // check if the array is empty.
        // if empty, reset all variables to defaults.
        // and send back a message 
        {
            if (first > last)
            {
                this.first = 0;
                this.last = -1;
                // maybe reallocate to a smaller starting queue?
                return "The Queue is empty";
            }
            return this.myQueue[first++];
        }

        internal string Peek()
        {
            if (first > last)
            {
                this.first = 0;
                this.last = -1;
                return "The Queue is empty";
            }
            return this.myQueue[first];
        }

        private void Reallocate()
        {
            // 2. implemente reallocation to a bigger array (when needed)
            // this will double the size of the array.

            // create an array of double the size
            string[] myNewArray = new string[size * 2];
            int m = 0;

            //get the back half
            for (int i = first; i < size - 1; i++)
            {
                myNewArray[m++] = this.myQueue[i];
            }

            // get the front half
            for (int i = 0; i <= last; i++)
            {
                myNewArray[m++] = this.myQueue[i];// continue with where we left off with m in the new array but at the beginning of the old array
            }

            // reset vars to defaults
            this.first = 0;
            this.last = m - 1;
            this.myQueue = myNewArray;// reassign the old array var to the new heap array allocation
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
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Mark")}");
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Arely")}");
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Ethan")}");

            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Mark")}");
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Arely")}");
            System.Console.WriteLine($"Enqueueing {myQueue.Enqueue("Ethan")}");


        }
    }
}
