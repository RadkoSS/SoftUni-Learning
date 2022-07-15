namespace WildFarm.Models.Animals
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models.Food;
    using Exceptions;
    using Exceptions.ExceptionMessages;

    public abstract class Animal
    {
        private string name;

        private double weight;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
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
                    throw new InvalidOperationException(string.Format(ExceptionMessage.StringIsNullEmptyOrWhitespacesMsg, nameof(this.Name)));
                }

                this.name = value;
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
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessage.NumberMustNotBeLessThanZeroMsg, nameof(this.Weight)));
                }

                this.weight = value;
            }
        }

        public int FoodEaten { get; private set; }

        public abstract IReadOnlyCollection<Type> PrefferedFoods { get; }

        public abstract double WeightModifier { get; }

        public abstract string AskForFood();

        public void Eat(Food food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidTypeOfFoodException(string.Format(ExceptionMessage.FoodNotPrefferedMsg, this.GetType().Name, food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightModifier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
