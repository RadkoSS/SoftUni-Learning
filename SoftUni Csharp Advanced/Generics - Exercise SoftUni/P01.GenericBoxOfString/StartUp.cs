using System;

namespace P01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main()
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                string line = Console.ReadLine();

                var box = new Box<string>(line);

                Console.WriteLine(box);
            }
        }
    }
}
