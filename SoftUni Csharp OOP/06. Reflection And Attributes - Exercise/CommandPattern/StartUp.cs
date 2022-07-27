namespace CommandPattern
{
    using IO;
    using IO.Contracts;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IWriter writer = new Writer();
            IReader reader = new Reader();

            IEngine engine = new Engine(command, writer, reader);
            engine.Run();
        }
    }
}
