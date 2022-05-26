using System;
using System.Collections.Generic;

namespace P06.Wardrobe
{
    class Program
    {
        static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            InitializeWardrobe(linesCount, wardrobe);

            Print(wardrobe);
        }

        static void InitializeWardrobe(int linesCount, Dictionary<string, Dictionary<string, int>> wardrobe)
        {

            for (int i = 0; i < linesCount; i++)
            {
                string[] clothes = Console.ReadLine().Split(" -> ");

                string color = clothes[0];

                string[] items = clothes[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (string item in items)
                {
                    if (wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item]++;
                    }
                    else
                    {
                        wardrobe[color].Add(item, 1);
                    }
                }
            }

        }

        static void Print(Dictionary<string, Dictionary<string, int>> wardrobe)
        {

            string[] colorAndItemToFind = Console.ReadLine().Split();

            foreach (KeyValuePair<string, Dictionary<string, int>> color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                Dictionary<string, int> currentColorClothes = color.Value;

                foreach (KeyValuePair<string, int> item in currentColorClothes)
                {
                    if (color.Key == colorAndItemToFind[0] && item.Key == colorAndItemToFind[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }

        }
    }
}
