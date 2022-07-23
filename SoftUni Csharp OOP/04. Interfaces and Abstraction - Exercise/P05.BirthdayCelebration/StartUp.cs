namespace BirthdayCelebration
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Models.Contracts;

    public class StartUp
    {
        static void Main()
        {
            string command;

            ICollection<IBirthtable> birthableList = new List<IBirthtable>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                string name = commandArgs[0];

                if (name == "Citizen")
                {
                    birthableList.Add(new Person(commandArgs[1], int.Parse(commandArgs[2]), commandArgs[3], commandArgs[4]));
                }
                else if (name == "Pet")
                {
                    birthableList.Add(new Pet(commandArgs[1], commandArgs[2]));
                }
            }

            string yearToSearch = Console.ReadLine();

            foreach (var birthtable in birthableList)
            {
                if (birthtable.BirthDate.EndsWith(yearToSearch))
                {
                    Console.WriteLine(birthtable.BirthDate);
                }
            }
        }
    }
}
