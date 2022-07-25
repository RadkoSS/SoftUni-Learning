namespace PizzaCalories.Models.Ingredients
{
    using System;
    using System.Collections.Generic;

    using Exceptions;

    public class Dough
    {
        private const double DoughBaseModifier = 2;

        private const int DoughMinWeight = 1;

        private const int DoughMaxWeight = 200;

        private string _flourType;

        private string _bakingTechnique;

        private double _grams;

        private readonly Dictionary<string, double> _modifiers;

        private Dough()
        {
            this._modifiers = new Dictionary<string, double>()
            {
                ["white"] = 1.5,
                ["wholegrain"] = 1,
                ["crispy"] = 0.9,
                ["chewy"] = 1.1,
                ["homemade"] = 1
            };
        }

        public Dough(string flourType, string bakingTechnique, double grams)
        : this()
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        private string FlourType
        {
            get => this._flourType;
            set
            {
                string toLower = value.ToLower();

                if (!_modifiers.ContainsKey(toLower))
                {
                    throw new InvalidTypeOfIngredientException(ExceptionMessages.DoughExceptionMessage);
                }

                this._flourType = toLower;
            }
        }

        private string BakingTechnique
        {
            get => this._bakingTechnique;
            set
            {
                string toLower = value.ToLower();

                if (!_modifiers.ContainsKey(toLower))
                {
                    throw new InvalidTypeOfIngredientException(ExceptionMessages.DoughExceptionMessage);
                }

                this._bakingTechnique = toLower;
            }
        }

        private double Grams
        {
            get => this._grams;
            set
            {
                if (value < DoughMinWeight || value > DoughMaxWeight)
                {
                    throw new ArgumentException(ExceptionMessages.WeightExceptionMessage);
                }

                this._grams = value;
            }
        }

        public double CaloriesPerGram => DoughBaseModifier * _modifiers[this.FlourType] * this.Grams *
                                         this._modifiers[this.BakingTechnique];

    }
}
