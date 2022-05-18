using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.FastFood
{
    internal class Program
    {
        static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            int biggestOrder = 0;

            while (ordersQueue.Count > 0)
            {
                if (ordersQueue.Peek() >= biggestOrder)
                {
                    biggestOrder = ordersQueue.Peek();
                }

                if (ordersQueue.Peek() <= foodQuantity)
                {
                    foodQuantity -= ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (ordersQueue.Count > 0)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
            else if (ordersQueue.Count == 0)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }
        }
    }
}
