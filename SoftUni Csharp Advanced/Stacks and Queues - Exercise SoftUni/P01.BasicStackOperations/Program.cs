using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.BasicStackOperations
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(number => int.Parse(number)).ToArray();

            int toPush = numbers[0];
            int toPop = numbers[1];
            int toLookFor = numbers[2];

            int[] numbersToPush = Console.ReadLine().Split(' ').Select(number => int.Parse(number)).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbersToPush.Length; i++)
            {
                stack.Push(numbersToPush[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            bool isFound = false;
            int smallestElement = int.MaxValue;

            foreach (var number in stack)
            {
                if (number == toLookFor)
                {
                    Console.WriteLine("true");
                    isFound = true;
                    break;
                }
                if (smallestElement > number)
                {
                    smallestElement = number;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (!isFound)
            {
                Console.WriteLine(smallestElement);
            }
        }
    }
}
