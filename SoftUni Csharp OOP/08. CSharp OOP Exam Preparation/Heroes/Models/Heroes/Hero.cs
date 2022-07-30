namespace Heroes.Models.Heroes
{
    using System;
    using System.Text;
    using Contracts;
    using Utilities.Exceptions;

    public abstract class Hero : IHero
    {
        private string _name;

        private int _health;

        private int _armour;

        private IWeapon _weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowException(ExceptionMessages.HeroNameIsNull);
                }

                this._name = value;
            }
        }

        public int Health
        {
            get => this._health;
            private set
            {
                if (value < 0)
                {
                    ThrowException(ExceptionMessages.HeroHealthIsBelowZero);
                }

                this._health = value;
            }
        }

        public int Armour
        {
            get => this._armour;
            private set
            {
                if (value < 0)
                {
                    ThrowException(ExceptionMessages.HeroArmourIsBelowZero);
                }

                this._armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this._weapon;
            private set
            {
                if (value == null)
                {
                    ThrowException(ExceptionMessages.WeaponInstanceIsNull);
                }

                this._weapon = value;
            }
        }

        public bool IsAlive => CheckIfHeroIsAlive;


        private bool CheckIfHeroIsAlive => this.Health > 0;


        private void ThrowException(string message) => throw new ArgumentException(message);


        public void TakeDamage(int points)
        {
            if (points > this.Armour)
            {
                int pointsToRemoveFromHealth = points - this.Armour;

                this.Armour = 0;

                if (this.Health - pointsToRemoveFromHealth < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= pointsToRemoveFromHealth;
                }
            }
            else
            {
                this.Armour -= points;
            }

        }

        public void AddWeapon(IWeapon weapon)
        {
            if (this.Weapon == null)
            {
                this.Weapon = weapon;
            }
        }

        public override string ToString()
        {
            StringBuilder outputBuilder = new StringBuilder();

            string weaponName = this.Weapon != null ? this.Weapon.Name : "Unarmed";

            outputBuilder.AppendLine($"{this.GetType().Name}: {this.Name}");
            outputBuilder.AppendLine($"--Health: {this.Health}");
            outputBuilder.AppendLine($"--Armour: {this.Armour}");
            outputBuilder.AppendLine($"--Weapon: {weaponName}");

            return outputBuilder.ToString().TrimEnd();
        }
    }
}
