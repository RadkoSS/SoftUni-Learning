using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Action<List<int>> print = list => Console.WriteLine(string.Join(' ', list));

            Func<List<int>, List<int>> applyCommands = null;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    applyCommands = list => list.Select(num => num += 1).ToList();
                    numbers = applyCommands(numbers);
                }
                else if (command == "multiply")
                {
                    applyCommands = list => list.Select(num => num *= 2).ToList();
                    numbers = applyCommands(numbers);
                }
                else if (command == "subtract")
                {
                    applyCommands = list => list.Select(num => num -= 1).ToList();
                    numbers = applyCommands(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
