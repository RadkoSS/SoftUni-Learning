using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = number => number % divider == 0;

            Action<List<int>> reverse = list => list.Reverse();

            Action<List<int>> remove = list => list.RemoveAll(number => isDivisible(number));

            reverse(numbers);
            remove(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
