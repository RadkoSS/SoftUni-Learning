namespace WildFarm.Models.Animals.Birds
{
    using System;

    using Interfaces;
    using Exceptions.ExceptionMessages;

    public abstract class Bird : Animal, IBird
    {
        private double wingSize;

        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get
            {
                return this.wingSize;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessage.NumberMustNotBeLessThanZeroMsg, nameof(this.WingSize)));
                }

                this.wingSize = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }
    }
}
