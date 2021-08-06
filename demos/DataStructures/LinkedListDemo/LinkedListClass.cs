

using System.Collections.Generic;
using System.Linq;

namespace LinkedListDemo
{
    public class LinkedListClass<T>
    {
        // variables
        private Envelope<T> Current { get; set; } = null;
        private Envelope<T> Head { get; set; } = null;
        private Envelope<T> Tail { get; set; } = null;

        // methods
        internal T AddToHead(T obj)
        {
            // check if there is a head. if NULL, add a new one to head.
            // if not null, create a new object and change head.previous to point ot this new one

            Envelope<T> newNode = new Envelope<T>();// create a new envelope
            newNode.Node = obj; // assign the oobject to the Node prop of the Envelope

            if (Head == null)
            {
                this.Head = newNode;        // assign the new node to be the head.
                this.Head.Next = null;      // keep these null because you give yourself a circular list
                this.Head.Previous = null;
                this.Current = newNode;     // current is the node we're pointing to ATM
                this.Tail = newNode;        //  
            }
            else
            {
                this.Head.Previous = newNode;   // reassign the heads previous prop to be the new env.
                newNode.Next = this.Head;       // assign the next of the new envelope to be the prev head
                this.Head = newNode;            // reassign the head to be the new envelope.
                this.Head.Previous = null;      // assign the new heads Previous prop to be null
                this.Current = this.Head;       // now the current node is the one we just inserted.
            }
            return Head.Node;
        }

        internal T AddToTail(T obj)
        {
            Envelope<T> newNode = new Envelope<T>();// create a new envelope
            newNode.Node = obj; // assign the oobject to the Node prop of the Envelope

            //check if this is the first node.
            if (Tail == null)
            {
                this.Tail = newNode; // assign the new node to be the head.
                Tail.Next = null;
                Tail.Previous = null;
                this.Current = newNode;
                this.Head = newNode;
            }
            else
            {
                this.Tail.Next = newNode;// reassign the tails Next prop to be the new env.
                newNode.Previous = this.Tail;// assign the next of the new env to be the prev head
                this.Tail = newNode;// reassign the head to be the new env.
            }
            return this.Tail.Node;
        }

        internal T GetCurrent() { return this.Current.Node; }

        internal T GetTail() { return this.Tail.Node; }

        internal T GetHead() { return this.Head.Node; }

        internal T DeleteNode(string name, int age)
        {
            // this gets around the generic T type and allows you to get the property value.
            // the below is called 'reflection'. It is a way to check out the property names, etc, of objects, etc 
            // var name1 = typeof(T).GetProperty("Name").GetValue(this.Current.Node);
            // var age1 = typeof(T).GetProperty("Age").GetValue(this.Current.Node);
            // if ((string)name1 == name && (int)age1 == age)
            // {
            //     return this.Current.Node;
            // }
            this.Current = this.Head;// make sure current is pointed to Head
            while (true)// infinite loop
            {
                if ((this.Current.Node as Person).Name == name && (this.Current.Node as Person).Age == age)
                {
                    T temp = this.Current.Node;
                    if (this.Current == this.Head)// if the node indicated is the head, there is no previous
                    {
                        this.Head = this.Current.Next;
                        this.Head.Previous = null;
                    }
                    else if (this.Current == this.Tail)// if the node indicated is the tail, there is no next
                    {
                        this.Tail = this.Current.Previous;
                        this.Tail.Next = null;
                    }
                    else
                    {
                        this.Current.Previous.Next = this.Current.Next;// redirect the previous node.
                        this.Current.Next.Previous = this.Current.Previous;// redirect the next node.
                        this.Current = this.Head;// make sure to hcange current back to Head or you're pointing to a dead node which is still working till GC.
                    }
                    return temp;
                }
                if (this.Current.Next != null)
                {
                    this.Current = this.Current.Next;
                }
                else
                {
                    this.Current = this.Head;
                    break;
                }
            }
            return default(T);
        }

        /// <summary>
        /// return the next node in the linked list step forward to that node.
        /// This is used to step through the linked list
        /// </summary>
        /// <returns></returns>
        internal T GetNext()
        {
            this.Current = this.Current.Next;
            if (this.Current != null) { return this.Current.Node; }
            else
            {
                this.Current = this.Head;
                return default(T);// this allows returning null of a type that's possibly non nullable.
            }
        }

        internal List<T> PrintLinkedList()
        {
            // return a List of the Persons
            List<T> persons = new List<T>();
            persons.Add(this.Current.Node);
            T temp = default(T);
            do
            {
                temp = this.GetNext();
                if (temp != null)
                {
                    persons.Add(temp);
                }
            } while (temp != null);

            return persons;
        }

        private class Envelope<T>
        {
            public Envelope<T> Next { get; set; } = null;    // points to the next object in the list
            public Envelope<T> Previous { get; set; } = null;// points to the object before this.
            public T Node { get; set; }
        }
    }
}