﻿namespace Gym.Models.Equipment
{
    using Contracts;

    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {
            this.Weight = weight;
            this.Price = price;
        }

        public double Weight { get; }

        public decimal Price { get; }

    }
}
