using System;

namespace StackDemo
{
    internal class StackClass
    {
        // variables
        private string[] myStack;
        private int top = -1;
        private int stackSize = 5;
        public int NumNames = 0;
        // public int Count { get; set; }

        // constructor
        public StackClass()
        {
            this.myStack = new string[this.stackSize];
        }

        /// <summary>
        /// check if the stack is already full and 
        /// increase the size of the array.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal string Push(string name)
        {
            //here check is the top is 1 fewer thant he size. If so, reallocate()


            top++;      //increment where the top is.
            this.myStack[top] = name; // assign the name
            return this.myStack[top];
        }

        /// <summary>
        /// pop takes off the top name on the stack.
        /// The implication is that you can't access that popped element value again.  
        /// you'll want to check that the stack has values first and 
        /// allert the usr that the stack is empty.
        /// </summary>
        /// <returns></returns>
        internal string Pop()
        {
            if (top == -1)
            {
                return "thie stack is empty";
            }
            else
            {
                top--;// decrement the top variable to htat the top is lower and the stak is smaller
                return myStack[top + 1];// return the value popped (just a courtesy)
            }

        }

        /// <summary>
        /// peek just returns the stacks top value
        /// </summary>
        /// <returns></returns>
        internal string Peek()
        {
            return myStack[top];
        }


        internal string PrintStack()
        {
            return "";
        }

        /// <summary>
        /// allocate a new array of double the size of the current array.
        /// then copy all the values into the new array.
        /// /// </summary>
        private void Reallocate()
        {
            throw new NotImplementedException($"this method isn't implemented yet!");

        }

        internal int GetNumNames()
        {
            return top + 1;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            StackClass myStack = new StackClass();

            //push some names
            System.Console.WriteLine($"Adding Mark");
            myStack.Push("Mark");

            System.Console.WriteLine($"Adding Arely");
            myStack.Push("Arely");

            System.Console.WriteLine($"Adding Ethan");
            myStack.Push("Ethan");

            // peek at it
            System.Console.WriteLine($"The top is {myStack.Peek()}");


            // pop some things...
            System.Console.WriteLine($"popping {myStack.Pop()}");
            System.Console.WriteLine($"The new top is {myStack.Peek()}");


            // peek at it



            // print the things

            //make it crash
            myStack.Push("Ethan");
            myStack.Push("Ethan");
            myStack.Push("Ethan");
            myStack.Push("Ethan");

        }
    }
}
