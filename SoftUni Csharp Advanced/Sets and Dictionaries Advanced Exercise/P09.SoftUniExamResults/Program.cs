using System;
using System.Linq;
using System.Collections.Generic;

namespace P09.SoftUniExamResults
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            Dictionary<string, int> submissions = new Dictionary<string, int>();

            ExecuteCommands(results, submissions);

            PrintSortedDictionaries(results, submissions);
        }

        static void ExecuteCommands(Dictionary<string, int> results, Dictionary<string, int> submissions)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] commandArguments = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = commandArguments[0];

                if (commandArguments.Length == 3)
                {
                    string language = commandArguments[1];
                    int points = int.Parse(commandArguments[2]);

                    if (!results.ContainsKey(username))
                        results.Add(username, points);
                    else
                    {
                        if (points > results[username])
                        {
                            results[username] = points;
                        }
                    }

                    if (!submissions.ContainsKey(language))
                        submissions.Add(language, 1);

                    else
                        submissions[language]++;

                }

                else if (commandArguments.Length == 2)
                    results.Remove(username);
            }
        }
        static void PrintSortedDictionaries(Dictionary<string, int> results, Dictionary<string, int> submissions)
        {
            Console.WriteLine("Results:");
            foreach (var result in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{result.Key} | {result.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
