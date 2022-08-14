namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Models.Planets;
    using Models.Weapons;
    using Utilities.Messages;
    using Models.MilitaryUnits;
    using Repositories.Contracts;
    using Models.Planets.Contracts;
    using Models.Weapons.Contracts;
    using Models.MilitaryUnits.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IPlanet> _planetsRepository;

        public Controller()
        {
            this._planetsRepository = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = this._planetsRepository.Models.FirstOrDefault(x => x.Name == name);

            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);

            this._planetsRepository.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, planet.Name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet searchedPlanet = this._planetsRepository.FindByName(planetName);

            if (searchedPlanet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IMilitaryUnit unit = searchedPlanet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName);

            if (unit != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit createUnit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),

                nameof(SpaceForces) => new SpaceForces(),

                nameof(StormTroopers) => new StormTroopers(),

                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName))
            };

            searchedPlanet.Spend(createUnit.Cost);

            searchedPlanet.AddUnit(createUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet searchedPlanet = this._planetsRepository.FindByName(planetName);

            if (searchedPlanet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IWeapon weapon = searchedPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName);

            if (weapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon createWeapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),

                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),

                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),

                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName))
            };

            searchedPlanet.Spend(createWeapon.Price);

            searchedPlanet.AddWeapon(createWeapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet searchedPlanet = this._planetsRepository.FindByName(planetName);

            if (searchedPlanet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (searchedPlanet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            searchedPlanet.Spend(1.25);

            searchedPlanet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet first = this._planetsRepository.FindByName(planetOne);

            IPlanet second = this._planetsRepository.FindByName(planetTwo);

            if (first.MilitaryPower > second.MilitaryPower)
            {
                first.Spend(first.Budget * 0.5);
                first.Profit(second.Budget * 0.5);
                first.Profit(second.Army.Sum(x => x.Cost));
                first.Profit(second.Weapons.Sum(x => x.Price));

                this._planetsRepository.RemoveItem(planetTwo);
                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else if (second.MilitaryPower > first.MilitaryPower)
            {
                second.Spend(second.Budget * 0.5);
                second.Profit(first.Budget * 0.5);
                second.Profit(first.Army.Sum(x => x.Cost));
                second.Profit(first.Weapons.Sum(x => x.Price));

                this._planetsRepository.RemoveItem(planetOne);
                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            IWeapon firstHasNucWeapon = first.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");

            IWeapon secondHasNucWeapon = second.Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon");

            if (firstHasNucWeapon == null && secondHasNucWeapon == null)
            {
                first.Spend(first.Budget * 0.5);
                second.Spend(second.Budget * 0.5);
                return OutputMessages.NoWinner;
            }

            if (firstHasNucWeapon != null && secondHasNucWeapon != null)
            {
                first.Spend(first.Budget * 0.5);
                second.Spend(second.Budget * 0.5);
                return OutputMessages.NoWinner;
            }

            if (firstHasNucWeapon != null)
            {
                first.Spend(first.Budget * 0.5);
                first.Profit(second.Budget * 0.5);
                first.Profit(second.Army.Sum(x => x.Cost));
                first.Profit(second.Weapons.Sum(x => x.Price));

                this._planetsRepository.RemoveItem(planetTwo);

                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }

            second.Spend(second.Budget * 0.5);
            second.Profit(first.Budget * 0.5);
            second.Profit(first.Army.Sum(x => x.Cost));
            second.Profit(first.Weapons.Sum(x => x.Price));

            this._planetsRepository.RemoveItem(planetOne);
            return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
        }

        public string ForcesReport()
        {
            List<IPlanet> sortedPlanets = this._planetsRepository.Models.ToList().OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in sortedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
