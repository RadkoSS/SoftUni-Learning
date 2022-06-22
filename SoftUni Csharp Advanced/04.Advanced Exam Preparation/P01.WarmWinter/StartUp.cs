using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.WarmWinter
{
    public class StartUp
    {
        static void Main()
        {
            var hats = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var scarfs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var hatsStack = new Stack<int>(hats);

            var scarfsQueue = new Queue<int>(scarfs);

            var sets = new List<int>();

            while (hatsStack.Count > 0 && scarfsQueue.Count > 0)
            {
                var currentHat = hatsStack.Pop();
                var currentScarf = scarfsQueue.Peek();

                if (currentHat > currentScarf)
                {
                    currentScarf += currentHat;
                    scarfsQueue.Dequeue();

                    sets.Add(currentScarf);

                }
                else if (currentHat == currentScarf)
                {
                    currentHat++;
                    scarfsQueue.Dequeue();

                    hatsStack.Push(currentHat);
                }

            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
