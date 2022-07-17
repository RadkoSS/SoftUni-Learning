namespace Raiding
{
    using IO;
    using Core;
    using Core.Interfaces;
    using IO.Interfaces;

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
