using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            string[] firstDate = Console.ReadLine().Split();

            string[] secondDate = Console.ReadLine().Split();

            DateModifier first = new DateModifier(firstDate[0], firstDate[1], firstDate[2]);

            DateModifier seacond = new DateModifier(secondDate[0], secondDate[1], secondDate[2]);


        }
    }
}
