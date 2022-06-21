using System;

namespace FishingNet
{
    public class Fish : IComparable<Fish>
    {
        public string FishType { get; set; }

        public double Length { get; set; }

        public double Weight { get; set; }

        public Fish(string fishType, double lenght, double weight)
        {
            FishType = fishType;
            Length = lenght;
            Weight = weight;
        }

        public int CompareTo(Fish other)
        {
            return Length.CompareTo(other.Length);
        }

        public override string ToString()
        {
            return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
        }
    }
}
