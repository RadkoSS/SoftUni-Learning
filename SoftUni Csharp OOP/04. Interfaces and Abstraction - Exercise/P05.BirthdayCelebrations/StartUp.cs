namespace P05.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class StartUp
    {
        static void Main()
        {
            string command;

            ICollection<Citizen> citizens = new List<Citizen>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs.Length == 2)
                {
                    citizens.Add(new Robot(commandArgs[0], commandArgs[1]));
                }
                else if (commandArgs.Length == 3)
                {
                    citizens.Add(new Person(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]));
                }
            }

            string fakeIds = Console.ReadLine();
            
            foreach (var citizen in citizens)
            {
                if (citizen.Id.EndsWith(fakeIds))
                {
                    Console.WriteLine(citizen);
                }
            }

        }
    }
}
