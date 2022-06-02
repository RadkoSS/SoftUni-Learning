using System;

namespace P01.ActionPrint
{
    class ActionPrint
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = name => Console.WriteLine(name);

            Array.ForEach(names, print);
        }
    }
}