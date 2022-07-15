namespace WildFarm.Factories.Interfaces
{
    using Models.Food;

    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
