using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main()
        {
            int boxesCount = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();

            for (int i = 0; i < boxesCount; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            var indexesToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var box = new Box<int>(numbers);

            box.Swap(numbers, indexesToSwap[0], indexesToSwap[1]);

            Console.WriteLine(box);
        }
    }
}
