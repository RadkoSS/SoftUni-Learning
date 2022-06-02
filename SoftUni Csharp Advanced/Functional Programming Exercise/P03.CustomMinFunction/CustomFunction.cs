using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    class CustomFunction
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> getMin = numbers => numbers.Min();

            Console.WriteLine(getMin(numbers));
        }
    }
}
