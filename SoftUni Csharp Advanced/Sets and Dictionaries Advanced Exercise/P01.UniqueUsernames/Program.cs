using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    class Program
    {
        static void Main()
        {
            int usernamesCount = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < usernamesCount; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
