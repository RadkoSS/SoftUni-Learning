namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    
    using Contracts;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        protected MilitaryUnit(double cost)
        {

        }

        public double Cost => throw new NotImplementedException();

        public int EnduranceLevel => throw new NotImplementedException();

        public void IncreaseEndurance()
        {
            throw new NotImplementedException();
        }
    }
}
