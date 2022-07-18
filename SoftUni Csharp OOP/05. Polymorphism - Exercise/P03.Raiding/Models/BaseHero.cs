namespace Raiding.Models
{
    using System;

    using Exceptions;

    public abstract class BaseHero
    {
        private string _name;

        private int _power;

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidStringMessage, nameof(this.Name)));
                }

                _name = value;
            }
        }

        public int Power
        {
            get
            {
                return this._power;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidNumberMessage, nameof(this.Power)));
                }

                this._power = value;
            }
        }

        public abstract string CastAbility();

        //public override string ToString()
        //{
        //    return $"{this.Name} - {this.Power}";
        //}
    }
}
