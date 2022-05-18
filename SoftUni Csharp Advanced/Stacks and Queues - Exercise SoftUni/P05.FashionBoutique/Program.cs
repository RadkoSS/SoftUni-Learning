using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.FashionBoutique
{
    internal class Program
    {
        static void Main()
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> clothesStack = new Stack<int>(clothes);

            int capacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int sum = 0;

            while (clothesStack.Count > 0)
            {
                sum += clothesStack.Peek();

                if (sum <= capacity)
                {
                    clothesStack.Pop();
                }
                else
                {
                    racks++;
                    sum = 0;
                }
                
            }

            Console.WriteLine(racks);
        }
    }
}
