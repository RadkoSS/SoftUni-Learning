namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    
    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int _enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel 
        { 
            get => this._enduranceLevel;
            private set
            {
                if (value >= 20)
                {
                    this._enduranceLevel = 20;

                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }

                this._enduranceLevel = value;
            }
        }

        public void IncreaseEndurance() => this.EnduranceLevel++;

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
