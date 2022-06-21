using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.BakeryShop
{
    public class StartUp
    {
        static void Main()
        {
            var waterArray = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var flourArray = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var waterQueue = new Queue<double>(waterArray);

            var flourStack = new Stack<double>(flourArray);

            var bakedProducts = new Dictionary<string, int>
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            ExecuteCommands(ref waterQueue, ref flourStack, ref bakedProducts);

            PrintBakedProducts(waterQueue, flourStack, bakedProducts);
        }

        static void ExecuteCommands(ref Queue<double> waterQueue, ref Stack<double> flourStack, ref Dictionary<string, int> bakedProducts)
        {
            while (waterQueue.Count > 0 && flourStack.Count > 0)
            {
                var currentWater = waterQueue.Dequeue();
                var currentFlour = flourStack.Pop();

                var percentageOfWater = currentWater * 100 / (currentWater + currentFlour);

                if (percentageOfWater == 50)
                {
                    bakedProducts["Croissant"]++;
                }
                else if (percentageOfWater == 40)
                {
                    bakedProducts["Muffin"]++;
                }
                else if (percentageOfWater == 30)
                {
                    bakedProducts["Baguette"]++;
                }
                else if (percentageOfWater == 20)
                {
                    bakedProducts["Bagel"]++;
                }
                else
                {
                    double toAdd = currentFlour - currentWater;

                    bakedProducts["Croissant"]++;

                    flourStack.Push(toAdd);
                }

            }
        }

        static void PrintBakedProducts(Queue<double> waterQueue, Stack<double> flourStack, Dictionary<string, int> bakedProducts)
        {
            foreach (var product in bakedProducts.OrderByDescending(product => product.Value).ThenBy(product => product.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }

            if (waterQueue.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flourStack.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }

    }
}
