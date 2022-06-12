using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();

            linkedList.AddFirst("Petko1");
            linkedList.AddLast("Petko2");
            linkedList.AddFirst("Radko");
            linkedList.AddLast("Last item");
            linkedList.AddLast("I must be removed");

            linkedList.RemoveLast();

            Console.WriteLine("Using ForEach to print:");
            linkedList.ForEach(name => Console.WriteLine(name));

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            Console.WriteLine("Using ForEach to print:");
            linkedList.ForEach(name => Console.WriteLine(name));

            var array = linkedList.ToArray();
            Console.WriteLine($"Printing the array: {string.Join(", ", array)}");

            var list = linkedList.ToList();
            Console.WriteLine($"Printing the list: {string.Join(" -> ", list)}");


            Console.WriteLine($"List count is {linkedList.Count()}.");

            Console.WriteLine("Search for:");
            string toLookFor = Console.ReadLine();

            Console.WriteLine($"Does the list contain {toLookFor}: {linkedList.Contains(toLookFor)}");

            Console.WriteLine("Clearing list...");

            Console.WriteLine($"List count is {linkedList.Count()}.");
        }
    }
}
