namespace PizzaCalories.Models.Ingredients
{
    using System;
    using System.Collections.Generic;

    using Exceptions;

    public class Topping
    {
        private const int ToppingBaseCaloriesPerGram = 2;

        private const int MinAllowedWeight = 1;

        private const int MaxAllowedWeight = 50;

        private string _type;

        private double _grams;

        private readonly Dictionary<string, double> _modifiers;

        private Topping()
        {
            this._modifiers = new Dictionary<string, double>()
            {
                ["meat"] = 1.2,
                ["veggies"] = 0.8,
                ["cheese"] = 1.1,
                ["sauce"] = 0.9
            };
        }

        public Topping(string type, double grams) : this()
        {
            this.Type = type;
            this.Grams = grams;
        }

        private string Type
        {
            get => this._type;
            set
            {
                string toLower = value.ToLower();

                if (!_modifiers.ContainsKey(toLower))
                {
                    throw new InvalidTypeOfIngredientException(string.Format(ExceptionMessages.ToppingExceptionMessage, value));
                }

                this._type = toLower;
            }
        }

        private double Grams
        {
            get => this._grams;
            set
            {
                if (value < MinAllowedWeight || value > MaxAllowedWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ToppingWeightExceptionMessage,
                        this.Type));
                }

                this._grams = value;
            }
        }

        public double CaloriesPerGram => ToppingBaseCaloriesPerGram * this.Grams * this._modifiers[this.Type];
    }
}
