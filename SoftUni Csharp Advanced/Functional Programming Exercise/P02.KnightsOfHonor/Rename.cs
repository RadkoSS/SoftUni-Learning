using System;

namespace P02.KnightsOfHonor
{
    class Rename
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = name => Console.WriteLine($"Sir {name}");

            Array.ForEach(names, print);
        }
    }
}
