using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.TruckTour
{
    internal class Program
    {
        static void Main()
        {
            long numberOfPumps = long.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPumps; i++)
            {
                long[] quantityAndDistance = Console.ReadLine().Split().Select(long.Parse).ToArray();


            }
        }
    }
}
