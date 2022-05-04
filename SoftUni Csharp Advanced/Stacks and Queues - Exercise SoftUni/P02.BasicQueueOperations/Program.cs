using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.BasicQueueOperations
{
    internal class Program
    {
        static void Main()
        {

            Queue<int> queue = new Queue<int>();

            int[] numbers = Console.ReadLine().Split(' ').Select(number => int.Parse(number)).ToArray();

            int toEnqueue = numbers[0];
            int toDequeue = numbers[1];
            int toLookFor = numbers[2];

            int[] numbersToPush = Console.ReadLine().Split(' ').Select(number => int.Parse(number)).ToArray();

            for (int i = 0; i < numbersToPush.Length; i++)
            {
                queue.Enqueue(numbersToPush[i]);
            }
            for (int i = 0; i < toDequeue; i++)
            {
                queue.Dequeue();
            }

            bool isFound = false;
            int smallestElement = int.MaxValue;

            foreach (var number in queue)
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

            if (queue.Count == 0)
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
