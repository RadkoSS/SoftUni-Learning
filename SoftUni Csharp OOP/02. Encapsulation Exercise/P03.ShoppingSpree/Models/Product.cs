namespace ShoppingSpree.Models
{
    using System;

    public class Product
    {
        private string _name;

        private decimal _cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }

                this._name = value;
            }
        }

        public decimal Cost
        {
            get => this._cost;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Cost)} cannot be negative");
                }

                this._cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
