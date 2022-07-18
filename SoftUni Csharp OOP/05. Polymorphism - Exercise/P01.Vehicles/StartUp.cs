namespace Vehicles
{
    using IO;
    using Core;
    using IO.Interfaces;
    using Core.Interfaces;

    public class StartUp
    {
        static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader, writer);

            engine.RunApplication();
        }
    }
}
