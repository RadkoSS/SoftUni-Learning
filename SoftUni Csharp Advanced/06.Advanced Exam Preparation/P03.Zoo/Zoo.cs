using System;
using System.Text;
using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> AnimalsList { get; set; }

        public IReadOnlyCollection<Animal> Animals => AnimalsList;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            AnimalsList = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public string AddAnimal(Animal animal)
        {
            var speciesIsInvalid = string.IsNullOrEmpty(animal.Species);

            var dietIsInvalid = animal.Diet != "herbivore" && animal.Diet != "carnivore" ? true : false;

            if (AnimalsList.Count == Capacity)
            {
                return "The zoo is full.";
            }
            else if (speciesIsInvalid)
            {
                return "Invalid animal species.";
            }
            else if (dietIsInvalid)
            {
                return "Invalid animal diet.";
            }

            AnimalsList.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            var countOfRemoved = AnimalsList.FindAll(animal => animal.Species == species).Count;

            AnimalsList.RemoveAll(animal => animal.Species == species);

            return countOfRemoved;
        }

        public List<Animal> GetAnimalsByDiet(string diet) => AnimalsList.FindAll(animal => animal.Diet == diet);

        public Animal GetAnimalByWeight(double weight) => AnimalsList.Find(animal => animal.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var count = 0;
            foreach (var animal in AnimalsList)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
