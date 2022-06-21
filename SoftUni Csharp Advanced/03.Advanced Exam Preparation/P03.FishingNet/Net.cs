using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> FishList { get; set; }

        public IReadOnlyCollection<Fish> Fish => FishList;

        public string Material { get; set; }

        public int Capacity { get; set; }

        public Net()
        {
            FishList = new List<Fish>();
        }

        public Net(string material, int capacity) : this()
        {
            Material = material;
            Capacity = capacity;
        }

        public int Count => FishList.Count;

        public string AddFish(Fish fish)
        {
            var fishTypeIsIncorrect = string.IsNullOrEmpty(fish.FishType);

            var isLenghtInvalid = fish.Length <= 0 ? true : false;

            var isWeightInvalid = fish.Weight <= 0 ? true : false;

            if (FishList.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            else if (isLenghtInvalid || isWeightInvalid || fishTypeIsIncorrect)
            {
                return "Invalid fish.";
            }

            FishList.Add(fish);

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var searchedFish = FishList.FirstOrDefault(fish => fish.Weight == weight);

            if (searchedFish != null)
            {
                return FishList.Remove(searchedFish);
            }
            return false;
        }

        public Fish GetFish(string fishType) => FishList.FirstOrDefault(fish => fish.FishType == fishType);

        public Fish GetBiggestFish()
        {
            if (FishList.Count == 0)
            {
                return null;
            }
            else if (FishList.Count == 1)
            {
                return FishList.First();
            }

            var longestFish = FishList.First();

            foreach (var fish in FishList)
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
            reportText.Append(string.Join(Environment.NewLine, FishList));

            return reportText.ToString().TrimEnd();
        }
    }
}
