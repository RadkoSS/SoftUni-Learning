namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    using Exceptions;
    using Ingredients;

    public class Pizza
    {
        private const double MaxToppingsCount = 10;

        private string _name;

        private readonly ICollection<Topping> _toppings;

        private Pizza()
        {
            this._toppings = new List<Topping>();
        }

        public Pizza(string name) : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException(ExceptionMessages.PizzaNameExceptionMessage);
                }

                this._name = value;
            }
        }

        public Dough Dough { get; set; }

        public int NumberOfToppings => this._toppings.Count;

        public double TotalCalories => CountCalories();

        public void AddTopping(Topping toping)
        {
            if (this.NumberOfToppings > MaxToppingsCount)
            {
                throw new ArgumentException(ExceptionMessages.ToppingsOutOfRangeMessage);
            }

            this._toppings.Add(toping);
        }

        private double CountCalories()
        {
            double totalCalories = this.Dough.CaloriesPerGram;

            foreach (var topping in this._toppings)
            {
                totalCalories += topping.CaloriesPerGram;
            }

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
