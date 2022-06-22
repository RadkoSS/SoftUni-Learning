using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> IngredientsList { get; set; }

        private int currentAlcoholLevel;

        public IReadOnlyCollection<Ingredient> Ingredients => IngredientsList;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int CurrentAlcoholLevel => currentAlcoholLevel;

        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            IngredientsList = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            var sameIngredient = FindIngredient(ingredient.Name);

            if (sameIngredient != null || IngredientsList.Count == Capacity || ingredient.Alcohol + currentAlcoholLevel > MaxAlcoholLevel)
            {
                return;
            }

            currentAlcoholLevel += ingredient.Alcohol;

            IngredientsList.Add(ingredient);
        }

        public bool Remove(string name)
        {
            var searchedIngredient = FindIngredient(name);

            if (searchedIngredient != null)
            {
                currentAlcoholLevel -= searchedIngredient.Alcohol;

                return IngredientsList.Remove(searchedIngredient);
            }
            return false;
        }

        public Ingredient FindIngredient(string name) => IngredientsList.FirstOrDefault(ingredient => ingredient.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
        {
            if (IngredientsList.Count == 0)
            {
                return null;
            }
            else if (Ingredients.Count == 1)
            {
                return IngredientsList.First();
            }

            var mostAlcoholic = IngredientsList.First();
            foreach (var item in IngredientsList)
            {
                if (mostAlcoholic.CompareTo(item) < 0)
                {
                    mostAlcoholic = item;
                }
            }

            return mostAlcoholic;
        }

        public string Report()
        {
            var reportText = new StringBuilder();

            reportText.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            reportText.AppendLine(string.Join(Environment.NewLine, Ingredients));

            return reportText.ToString().TrimEnd();
        }
    }
}
