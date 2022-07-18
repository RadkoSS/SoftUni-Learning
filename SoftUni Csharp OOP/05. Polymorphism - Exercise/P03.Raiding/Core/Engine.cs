namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;

    using Exceptions;
    using Interfaces;

    using IO.Interfaces;
    using Factories.Interfaces;

    using Models;
    using Factories;

    public class Engine : IEngine
    {
        private readonly IReader _reader;

        private readonly IWriter _writer;

        private readonly IFactory _factory;

        private readonly ICollection<BaseHero> _raidGroup;

        private Engine()
        {
            this._raidGroup = new List<BaseHero>();
            this._factory = new Factory();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this._reader = reader;
            this._writer = writer;
        }

        public void RunApplication()
        {
            int countOfHeroes = int.Parse(this._reader.ReadLine());

            int totalHeroesPower = CreateHeroesUsingFactory(countOfHeroes);

            int bossPower = int.Parse(this._reader.ReadLine());

            foreach (BaseHero hero in this._raidGroup)
            {
                this._writer.WriteLine(hero.CastAbility());
            }

            this._writer.WriteLine(totalHeroesPower >= bossPower ? "Victory!" : "Defeat...");
        }

        private int CreateHeroesUsingFactory(int countOfHeroes)
        {
            int totalPower = 0;

            for (int index = 0; index < countOfHeroes; index++)
            {
                try
                {
                    string heroName = this._reader.ReadLine();
                    string heroType = this._reader.ReadLine();

                    BaseHero hero = this._factory.CreateHero(heroName, heroType);

                    totalPower += hero.Power;

                    this._raidGroup.Add(hero);
                }
                catch (InvalidHeroException ihe)
                {
                    this._writer.WriteLine(ihe.Message);
                    index--;
                }
                catch (ArgumentOutOfRangeException)
                {
                    this._writer.WriteLine("Invalid input!");
                }
                catch (ArgumentException ae)
                {
                    this._writer.WriteLine(ae.Message);
                }
            }

            return totalPower;
        }
    }
}
