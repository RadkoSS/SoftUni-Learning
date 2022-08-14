namespace PlanetWars.Models.Planets.Contracts
{
    using System.Collections.Generic;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    public interface IPlanet
    {
        string Name { get; }

        double Budget { get; }

        double MilitaryPower { get; }

        public IReadOnlyCollection<IMilitaryUnit> Army { get; }
        public IReadOnlyCollection<IWeapon> Weapons { get; }

        void AddUnit(IMilitaryUnit unit);

        void AddWeapon(IWeapon weapon);

        void TrainArmy();

        void Spend(double amount);

        void Profit(double amount);

        string PlanetInfo();
    }
}
