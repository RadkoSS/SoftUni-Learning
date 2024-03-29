﻿namespace PersonsInfo
{
    using System.Collections.Generic;

    public class Team
    {
        private string name;

        private List<Person> firstTeam;

        private List<Person> reserveTeam;

        private Team()
        {
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public Team(string name) : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam;

        public IReadOnlyCollection<Person> ReserveTeam => this.reserveTeam;

        public void AddPlayer(Person person) 
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
