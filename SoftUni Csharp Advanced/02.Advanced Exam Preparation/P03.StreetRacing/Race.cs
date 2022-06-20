using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public Race()
        {
            this.Participants = new List<Car>();
        }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower) : this()
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            var sameCarFound = this.Participants.Any(x => x.LicensePlate == car.LicensePlate);

            if (!sameCarFound && car.HorsePower <= this.MaxHorsePower && this.Participants.Count < this.Capacity)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var searchedCar = FindParticipant(licensePlate);

            if (searchedCar != null)
            {
                this.Participants.Remove(searchedCar);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licencePlate) => this.Participants.FirstOrDefault(car => car.LicensePlate == licencePlate);

        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count == 0)
            {
                return null;
            }

            if (this.Participants.Count == 1)
            {
                return this.Participants.First();
            }

            var mostPowerfulCar = this.Participants.First();

            foreach (var car in this.Participants)
            {
                if (mostPowerfulCar.CompareTo(car) < 0)
                {
                    mostPowerfulCar = car;
                }
            }

            return mostPowerfulCar;
        }

        public string Report()
        {
            var outputText = new StringBuilder();

            outputText.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            if (this.Participants.Count > 0)
            {
                outputText.Append(string.Join(Environment.NewLine, this.Participants));
            }
            
            return outputText.ToString().TrimEnd();
        }
    }
}
