using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main()
        {
            int boxesCount = int.Parse(Console.ReadLine());
            List<string> strings = new List<string>();

            for (int i = 0; i < boxesCount; i++)
            {
                strings.Add(Console.ReadLine());
            }

            var indexesToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var box = new Box<string>(strings);

            box.Swap(strings, indexesToSwap[0], indexesToSwap[1]);

            Console.WriteLine(box);
        }
    }
}
