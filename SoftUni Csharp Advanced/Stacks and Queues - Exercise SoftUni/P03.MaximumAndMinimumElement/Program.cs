using System;
using System.Collections.Generic;

namespace P03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                if (command.Length > 1)
                {
                    int numberToPush = int.Parse(command.Substring(2, command.Length - 2));
                    stack.Push(numberToPush);
                }
                else if (command == "2")
                {
                    stack.Pop();
                }
                if (stack.Count == 0)
                {
                    continue;
                }
                else if (command == "3")
                {
                    int maxElement = int.MinValue;

                    foreach (int number in stack)
                    {
                        if (number > maxElement)
                        {
                            maxElement = number;
                        }
                    }
                    Console.WriteLine(maxElement);
                }
                else if (command == "4")
                {
                    int minElement = int.MaxValue;

                    foreach (int number in stack)
                    {
                        if (number < minElement)
                        {
                            minElement = number;
                        }
                    }
                    Console.WriteLine(minElement);
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
