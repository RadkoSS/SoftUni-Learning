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

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("Using ForEach method to print the items in the collection:");
            linkedList.ForEach(name => Console.WriteLine(name));

            Console.WriteLine("-----------------------------------------");

            //linkedList.RemoveFirst();
            //linkedList.RemoveLast();

            var array = linkedList.ToArray();
            Console.WriteLine($"Printing the array: {string.Join(", ", array)}");
            Console.WriteLine();

            var list = linkedList.ToList();
            Console.WriteLine($"Printing the list: {string.Join(" -> ", list)}");
            Console.WriteLine();


            Console.WriteLine($"List count is {linkedList.Count()}.");

            Console.WriteLine("Search for:");
            string toLookFor = Console.ReadLine();

            Console.WriteLine($"Does the list contain {toLookFor}: {linkedList.Contains(toLookFor)}");


            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Printing the collection using a foreach loop (this way we are utilizing the IEnumerable (yield return method)implementation)");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");


            Console.WriteLine("Clearing list...");
            linkedList.Clear();
            Console.WriteLine($"List count is {linkedList.Count()}.");
        }
    }
}
