using System;
using System.Collections.Generic;

namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a LinkedList Class Obj
            LinkedListClass<Person> myLinkedList = new LinkedListClass<Person>();

            Person p1 = new Person("Mark", 42);
            Person p2 = new Person("Arely", 38);
            Person p3 = new Person("Ethan", 16);
            Person p4 = new Person("Hope", 14);
            Person p6 = new Person("Maya", 2);

            myLinkedList.AddToHead(p1);
            myLinkedList.AddToHead(p2);
            myLinkedList.AddToHead(p3);
            myLinkedList.AddToHead(p4);
            myLinkedList.AddToTail(p6);
            myLinkedList.AddToTail(p1);
            myLinkedList.AddToTail(p2);
            myLinkedList.AddToTail(p3);

            List<Person> persons = myLinkedList.PrintLinkedList();
            foreach (var item in persons)
            {
                System.Console.WriteLine($"The person is {item.Name}, aged {item.Age}");
            }

            System.Console.WriteLine($"The Head is {myLinkedList.GetHead().Name}");
            System.Console.WriteLine($"The Tail is {myLinkedList.GetTail().Name}");
            System.Console.WriteLine($"The Current Node is {myLinkedList.GetCurrent().Name}");

            System.Console.WriteLine($"Deleting {myLinkedList.DeleteNode("Mark", 42).Name}");
            List<Person> persons1 = myLinkedList.PrintLinkedList();
            foreach (var item in persons1)
            {
                System.Console.WriteLine($"The person is {item.Name}, aged {item.Age}");
            }



            System.Console.WriteLine("Did it all print?");




        }
    }
}
