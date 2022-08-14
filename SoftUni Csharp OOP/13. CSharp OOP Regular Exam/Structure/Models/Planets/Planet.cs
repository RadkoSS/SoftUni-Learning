namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using MilitaryUnits.Contracts;
    using Weapons.Contracts;

    public abstract class Planet : IPlanet
    {
        protected Planet(string name, double budget)
        {

        }

        public string Name => throw new NotImplementedException();

        public double Budget => throw new NotImplementedException();

        public double MilitaryPower => throw new NotImplementedException();

        public IReadOnlyCollection<IMilitaryUnit> Army => throw new NotImplementedException();

        public IReadOnlyCollection<IWeapon> Weapons => throw new NotImplementedException();

        public void AddUnit(IMilitaryUnit unit)
        {
            throw new NotImplementedException();
        }

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void TrainArmy()
        {
            throw new NotImplementedException();
        }

        public void Spend(double amount)
        {
            throw new NotImplementedException();
        }

        public void Profit(double amount)
        {
            throw new NotImplementedException();
        }

        public string PlanetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
