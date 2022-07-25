namespace ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string _name;

        private decimal _money;

        private readonly ICollection<Product> _bagOfProducts;

        private Person()
        {
            this._bagOfProducts = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                }

                this._name = value;
            }
        }

        public decimal Money
        {
            get => this._money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }

                this._money = value;
            }
        }

        public bool BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                return false;
            }

            this.Money -= product.Cost;

            this._bagOfProducts.Add(product);

            return true;
        }

        public override string ToString()
        {
            if (this._bagOfProducts.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this._bagOfProducts)}";
        }
    }
}
