using System;
using System.Text;

namespace CocktailParty
{
    public class Ingredient : IComparable<Ingredient>
    {
        public string Name { get; set; }

        public int Alcohol { get; set; }

        public int Quantity { get; set; }

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public int CompareTo(Ingredient other) => Alcohol.CompareTo(other.Alcohol);

        public override string ToString()
        {
            var outputText = new StringBuilder();

            outputText.AppendLine($"Ingredient: {Name}");
            outputText.AppendLine($"Quantity: {Quantity}");
            outputText.AppendLine($"Alcohol: {Alcohol}");

            return outputText.ToString().TrimEnd();
        }
    }
}
