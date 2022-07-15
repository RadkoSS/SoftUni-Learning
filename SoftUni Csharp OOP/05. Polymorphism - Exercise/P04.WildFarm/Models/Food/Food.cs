namespace WildFarm.Models.Food
{
    using System;

    using Exceptions.ExceptionMessages;

    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity 
        { 
            get 
            { 
                return this.quantity;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessage.NumberMustNotBeLessThanZeroMsg, nameof(this.Quantity)));
                }

                this.quantity = value;
            }
        }
    }
}
