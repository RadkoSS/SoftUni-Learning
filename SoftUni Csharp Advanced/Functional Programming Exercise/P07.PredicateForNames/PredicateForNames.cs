using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main()
        {
            int nameLenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Action<List<string>> printValidNames = (List<string> list) => Console.WriteLine(string.Join(Environment.NewLine, list.FindAll((string name) => name.Length <= nameLenght)));

            printValidNames(names);
        }
    }
}