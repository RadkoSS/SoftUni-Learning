using System;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    class OddOrEven
    {
        static void Main()
        {
            int[] bordersOfArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = bordersOfArray[0];
            int end = bordersOfArray[1];

            int[] numbers = new int[end - start + 1];

            for (int number = start, index = 0; number <= end; number++, index++)
            {
                numbers[index] = number;
            }

            string type = Console.ReadLine();

            Predicate<int> predicate = null;

            if (type == "even")
            {
                predicate = number => number % 2 == 0;
            }
            else if (type == "odd")
            {
                predicate = number => number % 2 != 0;
            }

            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
