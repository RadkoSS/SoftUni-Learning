using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.SetsOfElements
{
    class Program
    {
        static void Main()
        {
            int[] lenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lenghts[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < lenghts[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(' ', firstSet));
        }
    }
}
