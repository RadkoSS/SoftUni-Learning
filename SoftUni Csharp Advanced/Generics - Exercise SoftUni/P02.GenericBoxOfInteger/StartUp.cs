using System;

namespace P02.GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main()
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfNumbers; i++)
            {
                int line = int.Parse(Console.ReadLine());

                var box = new Box<int>(line);

                Console.WriteLine(box);
            }
        }
    }
}
