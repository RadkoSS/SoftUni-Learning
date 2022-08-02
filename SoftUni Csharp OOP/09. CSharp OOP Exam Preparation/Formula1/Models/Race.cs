namespace Formula1.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities;

    public class Race : IRace
    {
        private string _raceName;

        private int _numberOfLaps;

        private Race()
        {
            this.TookPlace = false;
            this.Pilots = new List<IPilot>();
        }

        public Race(string raceName, int numberOfLaps) : this()
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get => this._raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    ThrowArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this._raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this._numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    ThrowArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this._numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }


        public ICollection<IPilot> Pilots { get; }


        private void ThrowArgumentException(string message) => throw new ArgumentException(message);


        public void AddPilot(IPilot pilot) => this.Pilots.Add(pilot);


        public string RaceInfo()
        {
            StringBuilder output = new StringBuilder();

            string tookPlace = this.TookPlace ? "Yes" : "No";

            output.AppendLine($"The {this.RaceName} race has:");
            output.AppendLine($"Participants: {this.Pilots.Count}");
            output.AppendLine($"Number of laps: {this.NumberOfLaps}");
            output.AppendLine($"Took place: {tookPlace}");

            return output.ToString().TrimEnd();
        }
    }
}
