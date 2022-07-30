namespace Heroes.Models.Weapons
{
    using System;
    using Utilities.Exceptions;
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private string _name;

        private int _durability;

        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowException(ExceptionMessages.WeaponTypeIsNull);
                }

                this._name = value;
            }
        }

        public int Durability
        {
            get => this._durability;
            protected set
            {
                if (value < 0)
                {
                    ThrowException(ExceptionMessages.DurabilityIsBelowZero);
                }

                this._durability = value;
            }
        }

        private void ThrowException(string message) => throw new ArgumentException(message);

        public abstract int DoDamage();
    }
}
