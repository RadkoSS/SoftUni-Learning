using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.Masterchef
{
    public class StartUp
    {
        static void Main()
        {
            var basketIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var freshnessArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dishes = new Dictionary<string, int>
            {
                { "Dipping sauce", 150 },
                { "Green salad", 250 },
                { "Chocolate cake", 300 },
                { "Lobster", 400 }
            };

            var cookedDishes = new Dictionary<string, int>
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };

            var queueIngredients = new Queue<int>(basketIngredients);

            var stackFreshness = new Stack<int>(freshnessArray);

            while (queueIngredients.Count > 0 && stackFreshness.Count > 0)
            {
                var currentIngr = queueIngredients.Dequeue();

                if (currentIngr == 0)
                {
                    continue;
                }

                var currentFreshness = stackFreshness.Peek();

                var multiplied = currentFreshness * currentIngr;

                if (dishes.Any(dish => dish.Value == multiplied))
                {
                    foreach (var dish in dishes)
                    {
                        if (multiplied == dishes[dish.Key])
                        {
                            cookedDishes[dish.Key]++;

                            stackFreshness.Pop();
                            break;
                        }
                    }
                }

                else
                {
                    stackFreshness.Pop();
                    currentIngr += 5;

                    queueIngredients.Enqueue(currentIngr);

                }

            }

            if (cookedDishes.Any(dish => dish.Value < 1))
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (queueIngredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {queueIngredients.Sum()}");
            }

            foreach (var dish in cookedDishes.OrderBy(dish => dish.Key).Where(dish => dish.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
