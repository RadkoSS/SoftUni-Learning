using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.MealPlan
{
    public class StartUp
    {
        static void Main()
        {
            var allowedMealsArray = Console.ReadLine().Split();

            var calloriesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queueMeals = new Queue<string>(allowedMealsArray);

            var stackCallories = new Stack<int>(calloriesArray);

            var mealPlan = new Dictionary<string, int> 
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 }
            };

            var mealsCount = 0;

            while (queueMeals.Count > 0 && stackCallories.Count > 0)
            {
                var currentMeal = queueMeals.Peek();

                var currentCallories = stackCallories.Pop();

                var difference = currentCallories - mealPlan[currentMeal];

                if (difference > 0)
                {
                    mealsCount++;
                    queueMeals.Dequeue();
                    stackCallories.Push(difference);
                }
                else
                {
                    var calloriesLeft = mealPlan[currentMeal] - currentCallories;

                    mealsCount++;

                    queueMeals.Dequeue();

                    if (stackCallories.Count > 0)
                    {
                        var nextDayCallories = stackCallories.Pop();
                        nextDayCallories -= calloriesLeft;

                        stackCallories.Push(nextDayCallories);

                    }
                }
            }

            if (queueMeals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCount} meals.");

                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", stackCallories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCount} meals.");

                Console.WriteLine($"Meals left: {string.Join(", ", queueMeals)}.");
            }
        }
    }
}
