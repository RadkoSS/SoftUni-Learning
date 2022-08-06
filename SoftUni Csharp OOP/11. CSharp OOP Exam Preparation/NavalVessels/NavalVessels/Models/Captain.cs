namespace NavalVessels.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Captain : ICaptain
    {
        private const int CombatXpIncrease = 10;

        private string _fullName;

        private Captain()
        {
            this.Vessels = new List<IVessel>();
        }

        public Captain(string fullName)
        : this()
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get => this._fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                this._fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience() => this.CombatExperience += CombatXpIncrease;

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                output.AppendLine(string.Join(Environment.NewLine, this.Vessels));
            }

            return output.ToString().TrimEnd();
        }
    }
}
