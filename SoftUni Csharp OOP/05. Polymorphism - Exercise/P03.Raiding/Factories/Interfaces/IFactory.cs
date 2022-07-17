namespace Raiding.Factories.Interfaces
{
    using Models;

    public interface IFactory
    {
        BaseHero CreateHero(string name, string heroType);
    }
}
