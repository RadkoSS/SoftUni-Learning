using System;
using System.Collections.Generic;

namespace P05.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main()
        {
            int countOfElements = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < countOfElements; i++)
            {
                list.Add(Console.ReadLine());
            }

            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();

            Console.WriteLine(box.CountOfLargerElements(list, elementToCompare));

        }
    }
}
