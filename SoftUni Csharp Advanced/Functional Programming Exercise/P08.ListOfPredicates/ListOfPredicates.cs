using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main()
        {
            int endOfRange = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();

            for (int number = 1; number <= endOfRange; number++)
            {
                numbers.Add(number);
            }

            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            //Func<int, List<int>, bool> isDivisible = (List<int> list) => dividers.FindAll(number => number % );
        }
    }
}
