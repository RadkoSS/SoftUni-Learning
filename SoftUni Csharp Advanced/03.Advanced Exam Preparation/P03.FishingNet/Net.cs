using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; private set; }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public Net()
        {
            Fish = new List<Fish>();
        }

        public Net(string material, int capacity) : this()
        {
            Material = material;
            Capacity = capacity;
        }

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            var fishTypeIsIncorrect = string.IsNullOrEmpty(fish.FishType);

            var isLenghtInvalid = fish.Lenght <= 0 ? true : false;

            var isWeightInvalid = fish.Weight <= 0 ? true : false;

            if (Fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            else if (isLenghtInvalid || isWeightInvalid || fishTypeIsIncorrect)
            {
                return "Invalid fish.";
            }

            Fish.Add(fish);

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var searchedFish = Fish.FirstOrDefault(fish => fish.Weight == weight);

            if (searchedFish != null)
            {
                return Fish.Remove(searchedFish);
            }
            return false;
        }

        public Fish GetFish(string fishType) => Fish.FirstOrDefault(fish => fish.FishType == fishType);

        public Fish GetBiggestFish()
        {
            if (Fish.Count == 0)
            {
                return null;
            }
            else if (Fish.Count == 1)
            {
                return Fish.First();
            }

            var longestFish = Fish.First();

            foreach (var fish in Fish)
            {
                if (longestFish.CompareTo(fish) < 0)
                {
                    longestFish = fish;
                }
            }

            return longestFish;
        }

        public string Report()
        {
            var reportText = new StringBuilder();

            reportText.AppendLine($"Into the {Material}:");
            reportText.Append(string.Join(Environment.NewLine, Fish));

            return reportText.ToString().TrimEnd();
        }
    }
}
