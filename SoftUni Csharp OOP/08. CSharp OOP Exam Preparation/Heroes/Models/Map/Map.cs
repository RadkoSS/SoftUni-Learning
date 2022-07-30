namespace Heroes.Models.Map
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.OutputMessages;

    public class Map : IMap
    {
        private readonly ICollection<IHero> _knights;

        private readonly ICollection<IHero> _barbarians;

        public Map()
        {
            this._knights = new List<IHero>();
            this._barbarians = new List<IHero>();
        }

        public string Fight(ICollection<IHero> players)
        {
            SplitFightersToDifferentCollections(players);

            BeginFighting();

            bool knightsAreAlive = this._knights.Any(k => k.IsAlive);

            int deadKnights = this._knights.Count(k => k.IsAlive == false);

            int deadBarbarians = this._barbarians.Count(b => b.IsAlive == false);

            if (knightsAreAlive)
            {
                return string.Format(OutputMessages.KnightWinBattle, deadKnights);
            }

            return string.Format(OutputMessages.BarbariansWinBattle, deadBarbarians);
        }

        private void SplitFightersToDifferentCollections(ICollection<IHero> players)
        {
            foreach (var hero in players)
            {
                Type heroType = hero.GetType();

                if (heroType.Name == "Knight")
                {
                    this._knights.Add(hero);
                }
                else if (heroType.Name == "Barbarian")
                {
                    this._barbarians.Add(hero);
                }

                //2nd method

                //if (hero is Knight knight)
                //{
                //    this._knights.Add(knight);
                //}
                //else if (hero is Barbarian barbarian)
                //{
                //    this._barbarians.Add(barbarian);
                //}

            }
        }

        private void BeginFighting()
        {
            while (this._barbarians.Any(barb => barb.IsAlive) && this._knights.Any(knight => knight.IsAlive))
            {
                foreach (var knight in this._knights)
                {
                    foreach (var barbarian in this._barbarians)
                    {
                        if (knight.IsAlive)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }

                        if (barbarian.IsAlive)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }
            }
        }
    }
}
