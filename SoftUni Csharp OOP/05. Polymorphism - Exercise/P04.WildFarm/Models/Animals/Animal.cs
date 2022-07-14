namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Models.Food;
    using Exceptions.ExceptionMessages;

    public abstract class Animal
    {
        private string name;

        private double weight;

        private int foodEaten;

        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(new ExceptionMessage().InvalidStringExceptionMessage, nameof(this.Name)));
                }

                this.Name = value;
            }
        }

        public double Weight 
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(new ExceptionMessage().NegativeNumberExceptionMessage, nameof(this.Weight)));
                }

                this.weight = value;
            }
        }

        public int FoodEaten 
        {
            get
            {
                return this.foodEaten;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(new ExceptionMessage().NegativeNumberExceptionMessage, nameof(this.FoodEaten)));
                }

                this.foodEaten = value;
            }
        }

        public abstract IReadOnlyCollection<Type> PrefferedFoods { get; }

        public abstract double WeightModifier { get; }

        public abstract string AskForFood();

        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
