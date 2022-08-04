namespace Gym.Models.Gyms
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;
    using Athletes.Contracts;
    using Equipment.Contracts;

    public abstract class Gym : IGym
    {
        private string _name;

        private Gym()
        {
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        protected Gym(string name, int capacity)
        : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ThrowArgumentException(ExceptionMessages.InvalidGymName);
                }

                this._name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight => this.Equipment.Sum(equipment => equipment.Weight);

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        private static void ThrowArgumentException(string message) => throw new ArgumentException(message);

        private static void ThrowInvalidOperationException(string message) => throw new InvalidOperationException(message);

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
            {
                ThrowInvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete) => this.Athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment) => this.Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder info = new StringBuilder();

            List<string> athletesNamesList = this.Athletes.Select(athlete => athlete.FullName).ToList();

            string athletesNames = athletesNamesList.Count > 0 ? string.Join(", ", athletesNamesList) : "No athletes";

            info.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            info.AppendLine($"Athletes: {athletesNames}");
            info.AppendLine($"Equipment total count: {this.Equipment.Count}");
            info.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return info.ToString().TrimEnd();
        }
    }
}
