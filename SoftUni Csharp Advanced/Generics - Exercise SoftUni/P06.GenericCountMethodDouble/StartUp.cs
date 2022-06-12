using System;
using System.Collections.Generic;

namespace P06.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main()
        {
            int countOfElements = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < countOfElements; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CountOfLargerElements(list, elementToCompare));
        }
    }
}
