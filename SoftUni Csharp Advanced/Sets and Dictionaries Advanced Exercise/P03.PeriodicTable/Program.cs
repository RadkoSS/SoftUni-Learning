using System;
using System.Collections.Generic;

namespace P03.PeriodicTable
{
    class Program
    {
        static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < elementsCount; i++)
            {
                string[] currentLine = Console.ReadLine().Split(' ');

                foreach (string element in currentLine)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', periodicTable));
        }
    }
}
