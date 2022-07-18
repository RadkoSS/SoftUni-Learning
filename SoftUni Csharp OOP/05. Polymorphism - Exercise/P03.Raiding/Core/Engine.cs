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
        private readonly IReader reader;

        private readonly IWriter writer;

        private readonly IFactory factory;

        private readonly ICollection<BaseHero> raidGroup;

        private Engine()
        {
            this.raidGroup = new List<BaseHero>();
            this.factory = new Factory();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void RunApplication()
        {
            int countOfHeroes = int.Parse(this.reader.ReadLine());

            int totalHeroesPower = CreateHeroesUsingFactory(countOfHeroes);

            int bossPower = int.Parse(this.reader.ReadLine());

            foreach (BaseHero hero in this.raidGroup)
            {
                this.writer.WriteLine(hero.CastAbility());
            }

            this.writer.WriteLine(totalHeroesPower >= bossPower ? "Victory!" : "Defeat...");
        }

        private int CreateHeroesUsingFactory(int countOfHeroes)
        {
            int totalPower = 0;

            for (int i = 0; i < countOfHeroes; i++)
            {
                try
                {
                    string heroName = this.reader.ReadLine();
                    string heroType = this.reader.ReadLine();

                    BaseHero hero = this.factory.CreateHero(heroName, heroType);

                    totalPower += hero.Power;

                    this.raidGroup.Add(hero);
                }
                catch (InvalidHeroException ihe)
                {
                    this.writer.WriteLine(ihe.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    this.writer.WriteLine("Invalid input!");
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }

            return totalPower;
        }
    }
}
