namespace Heroes.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;
    using Models.Heroes;
    using Models.Map;
    using Models.Weapons;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Exceptions;
    using Utilities.OutputMessages;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;

        private readonly IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = this.weapons.FindByName(name);

            if (weapon != null)
            {
                ThrowException(string.Format(ExceptionMessages.WeaponWithGivenNameExists, name));
            }

            string output = string.Empty;

            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);

                output = string.Format(OutputMessages.WeaponSuccessfullyAdded, type.ToLower(), name);
            }
            else if (type == "Mace")
            {
                weapon = new Mace(name, durability);

                output = string.Format(OutputMessages.WeaponSuccessfullyAdded, type.ToLower(), name);
            }
            else
            {
                ThrowException(ExceptionMessages.WeaponTypeIsInvalid);
            }

            this.weapons.Add(weapon);

            return output;
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heroes.FindByName(name);

            if (hero != null)
            {
                ThrowException(string.Format(ExceptionMessages.HeroWithGivenNameExists, name));
            }

            string output = string.Empty;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);

                output = string.Format(OutputMessages.KnightSuccessfullyAdded, name);
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);

                output = string.Format(OutputMessages.BarbarianSuccessfullyAdded, name);
            }
            else
            {
                ThrowException(ExceptionMessages.HeroTypeIsInvalid);
            }
            
            this.heroes.Add(hero);

            return output;
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero searchedHero = this.heroes.FindByName(heroName);

            IWeapon searchedWeapon = this.weapons.FindByName(weaponName);

            if (searchedHero == null)
            {
                ThrowException(string.Format(ExceptionMessages.HeroWithGivenNameDoesNotExist, heroName));
            }

            if (searchedWeapon == null)
            {
                ThrowException(string.Format(ExceptionMessages.WeaponWithGivenNameDoesNotExist, weaponName));
            }

            if (searchedHero?.Weapon != null)
            {
                ThrowException(string.Format(ExceptionMessages.HeroAlreadyHasWeapon, heroName));
            }

            searchedHero?.AddWeapon(searchedWeapon);

            return string.Format(OutputMessages.HeroCanParticipateInBattleUsingThisWeapon, heroName, searchedWeapon?.GetType().Name.ToLower());
        }

        public string StartBattle()
        {
            IMap map = new Map();

            List<IHero> heroes = this.heroes.Models.ToList();

            List<IHero> eligibleHeroes = heroes.FindAll(hero => hero.Weapon != null && hero.IsAlive == true);

            string result = map.Fight(eligibleHeroes);

            return result;
        }

        public string HeroReport()
        {
            StringBuilder output = new StringBuilder();

            List<IHero> sortedHeroes = this.heroes.Models.ToList().
                OrderBy(hero => hero.GetType().Name).ThenByDescending(hero => hero.Health).ThenBy(hero => hero.Name).ToList();

            foreach (var hero in sortedHeroes)
            {
                output.AppendLine(hero.ToString());
            }

            return output.ToString().TrimEnd();
        }

        private void ThrowException(string message) => throw new InvalidOperationException(message);
    }
}
