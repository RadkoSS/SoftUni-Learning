namespace PlanetWars.Models.Weapons
{
    using System;
    
    using Contracts;
    using Utilities.Messages;

    public abstract class Weapon : IWeapon
    {
        private int _destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }

        public double Price { get; private set; }

        public int DestructionLevel
        {
            get => this._destructionLevel;
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }

                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                this._destructionLevel = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
