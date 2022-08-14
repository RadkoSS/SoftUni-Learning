namespace PlanetWars.Models.Planets
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Weapons.Contracts;
    using Utilities.Messages;
    using Repositories.Contracts;
    using MilitaryUnits.Contracts;

    public class Planet : IPlanet
    {
        private readonly IRepository<IMilitaryUnit> _unitRepository;
        private readonly IRepository<IWeapon> _weaponRepository;

        private string _name;
        private double _budget;

        private Planet()
        {
            this._unitRepository = new UnitRepository();
            this._weaponRepository = new WeaponRepository();
        }

        public Planet(string name, double budget) : this()
        {
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                this._name = value;
            }
        }

        public double Budget
        {
            get => this._budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                this._budget = value;
            }
        }

        public double MilitaryPower => CalculatePreciseMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this._unitRepository.Models as IReadOnlyCollection<IMilitaryUnit>;

        public IReadOnlyCollection<IWeapon> Weapons => this._weaponRepository.Models as IReadOnlyCollection<IWeapon>;

        private double CalculatePreciseMilitaryPower()
        {
            double preciseAmount = this._unitRepository.Models.ToList().Sum(x => x.EnduranceLevel) +
                                   this._weaponRepository.Models.ToList().Sum(x => x.DestructionLevel);

            if (this.Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                preciseAmount *= 1.3;
            }

            if (this.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                preciseAmount *= 1.45;
            }

            return Math.Round(preciseAmount, 3);
        }

        public void AddUnit(IMilitaryUnit unit) => this._unitRepository.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => this._weaponRepository.AddItem(weapon);

        public void TrainArmy()
        {
            foreach (var force in this._unitRepository.Models)
            {
                force.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            this.Budget -= amount;
        }

        public void Profit(double amount) => this.Budget += amount;

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string forces = this.Army.Count > 0 ? string.Join(", ", this.Army) : "No units";

            string equipment = this.Weapons.Count > 0 ? string.Join(", ", this.Weapons) : "No weapons";

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {forces}");
            sb.AppendLine($"--Combat equipment: {equipment}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }
    }
}
