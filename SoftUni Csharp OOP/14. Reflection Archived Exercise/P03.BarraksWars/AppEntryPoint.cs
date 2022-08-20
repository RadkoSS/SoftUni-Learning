namespace _03BarracksFactory
{
    using Core;
    using Data;
    using Contracts;
    using Core.Factories;

    class AppEntryPoint
    {
        static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();

            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
