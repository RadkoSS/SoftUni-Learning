namespace Raiding.Factories
{
    using Models;
    using Models.Heroes;

    using Exceptions;
    using Interfaces;

    public class Factory : IFactory
    {
        public BaseHero CreateHero(string name, string heroType)
        {
            BaseHero hero;

            if (heroType == "Druid")
            {
                hero = new Druid(name);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidHeroException();
            }

            return hero;
        }
    }
}
