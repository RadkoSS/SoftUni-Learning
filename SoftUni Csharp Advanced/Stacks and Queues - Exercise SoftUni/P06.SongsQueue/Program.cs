using System;
using System.Collections.Generic;

namespace P06.SongsQueue
{
    internal class Program
    {
        static void Main()
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command.Substring(0, 3) == "Add")
                {
                    string songName = command.Substring(4);
                    if (!songsQueue.Contains(songName))
                    {
                        songsQueue.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }  
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
