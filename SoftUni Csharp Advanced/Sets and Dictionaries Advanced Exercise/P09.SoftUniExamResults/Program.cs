using System;
using System.Collections.Generic;

namespace P09.SoftUniExamResults
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> results = new Dictionary<string, Dictionary<string, int>>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] commandArguments = command.Split('-');
                string username = commandArguments[0];

                if (commandArguments.Length == 3)
                {
                    string language = commandArguments[1];
                    int points = int.Parse(commandArguments[2]);

                    if (!results.ContainsKey(language))
                    {
                        results.Add(language, new Dictionary<string, int>());
                    }
                    else
                    {
                        results[language].Add(username, points);
                    }
                }
                else if (commandArguments.Length == 2)
                {
                    results[username].TryGetValue(username, out int points);
                }
            }
        }
    }
}
