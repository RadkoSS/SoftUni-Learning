namespace CollectionHierarchy
{
    using IO;
    using Core;

    public class StartUp
    {
        static void Main()
        {
            ConsoleReader consoleReader = new ConsoleReader();
            ConsoleWriter consoleWriter = new ConsoleWriter();

            Engine engine = new Engine(consoleReader, consoleWriter);

            engine.Start();
        }
    }
}
