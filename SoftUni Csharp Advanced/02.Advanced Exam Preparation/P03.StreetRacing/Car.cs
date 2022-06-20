using System;
using System.Text;

namespace StreetRacing
{
    public class Car : IComparable<Car>
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int HorsePower { get; set; }

        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }

        public int CompareTo(Car other)
        {
            return this.HorsePower.CompareTo(other.HorsePower);
        }

        public override string ToString()
        {
            var outputText = new StringBuilder();

            outputText.AppendLine($"Make: {this.Make}");
            outputText.AppendLine($"Model: {this.Model}");
            outputText.AppendLine($"LicensePlate: {this.LicensePlate}");
            outputText.AppendLine($"HorsePower: {this.HorsePower}");
            outputText.AppendLine($"Weight: {this.Weight}");

            return outputText.ToString().TrimEnd();
        }
    }
}
