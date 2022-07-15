namespace WildFarm
{
    using IO;
    using IO.Interfaces;

    using Core;
    using Core.Interfaces;

    public class StartUp
    {
        static void Main()
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            IEngine engine = new AppEngine(writer, reader);

            engine.RunAplication();
        }
    }
}
