namespace FoodShortage.Models
{
    using System;
    using Contracts;

    public class Rebel : Person, IBuyer
    {
        public Rebel(string name, int age, string group)
        : base(name, age)
        {
            this.Group = group;
            this.Food = 0;
        }

        public string Group { get; }

        public int Food { get; private set; }

        public void BuyFood() => this.Food += 5;
    }
}
