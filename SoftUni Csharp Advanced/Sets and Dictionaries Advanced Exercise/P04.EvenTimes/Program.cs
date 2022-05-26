using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    class Program
    {
        static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < numbersCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(currentNumber))
                {
                    numbers[currentNumber]++;
                }
                else
                {
                    numbers.Add(currentNumber, -1);
                }
            }

            int numberToPrint = 0;
            foreach (KeyValuePair<int, int> pair in numbers)
            {
                if (pair.Value % 2 == 0)
                {
                    numberToPrint = pair.Key;
                }
            }
            Console.WriteLine(numberToPrint);
        }
    }
}
