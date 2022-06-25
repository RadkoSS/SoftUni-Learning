using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.TilesMaster
{
    public class StartUp
    {
        static void Main()
        {
            var arrayOfWhiteTiles = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var arrayOfGreyTiles = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queueGreyTiles = new Queue<int>(arrayOfGreyTiles);

            var stackWhiteTiles = new Stack<int>(arrayOfWhiteTiles);

            var table = new Dictionary<string, int>
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 }
            };

            var usedTiles = new Dictionary<string, int>
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0 },
                { "Wall", 0 },
                { "Floor", 0 }
            };

            PlaceTiles(ref queueGreyTiles, ref stackWhiteTiles, table, ref usedTiles);

            PrintResult(stackWhiteTiles, queueGreyTiles, usedTiles);
        }

        static void PlaceTiles(ref Queue<int> queueGreyTiles, ref Stack<int> stackWhiteTiles, Dictionary<string, int> table, ref Dictionary<string, int> usedTiles)
        {
            while (queueGreyTiles.Count > 0 && stackWhiteTiles.Count > 0)
            {
                var currentGrey = queueGreyTiles.Dequeue();

                var currentWhite = stackWhiteTiles.Pop();

                if (currentGrey == currentWhite)
                {
                    var sumOfArea = currentGrey + currentWhite;

                    if (table.Any(tile => tile.Value == sumOfArea))
                    {
                        var match = table.First(tile => tile.Value == sumOfArea).Key;

                        usedTiles[match]++;

                    }
                    else
                        usedTiles["Floor"]++;
                }

                else
                {
                    currentWhite /= 2;

                    stackWhiteTiles.Push(currentWhite);

                    queueGreyTiles.Enqueue(currentGrey);
                }
            }
        }

        static void PrintResult(Stack<int> stackWhiteTiles, Queue<int> queueGreyTiles, Dictionary<string, int> usedTiles)
        {
            if (stackWhiteTiles.Count > 0)
                Console.WriteLine($"White tiles left: {string.Join(", ", stackWhiteTiles)}");

            else
                Console.WriteLine("White tiles left: none");

            if (queueGreyTiles.Count > 0)
                Console.WriteLine($"Grey tiles left: {string.Join(", ", queueGreyTiles)}");

            else
                Console.WriteLine("Grey tiles left: none");

            foreach (var location in usedTiles.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
