namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            var countOfPlayers = int.Parse(Console.ReadLine());
            var playersList = new List<Person>();

            var team = new Team("TEAM 02");

            for (int player = 1; player <= countOfPlayers; player++)
            {
                var playerInfo = Console.ReadLine().Split();

                var firstName = playerInfo[0];
                var lastName = playerInfo[1];

                var age = int.Parse(playerInfo[2]);

                Person newPlayer = null;

                if (playerInfo.Length == 4)
                {      
                    newPlayer = new Person(firstName, lastName, age);
                }

                else if (playerInfo.Length == 5)
                {
                    var salary = decimal.Parse(playerInfo[3]);

                    newPlayer = new Person(firstName, lastName, age, salary);
                }

                playersList.Add(newPlayer);
            }

            foreach (var player in playersList)
            {
                team.AddPlayer(player);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");

            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
