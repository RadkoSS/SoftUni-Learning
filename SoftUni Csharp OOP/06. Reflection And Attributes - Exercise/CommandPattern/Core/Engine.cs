namespace CommandPattern.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader _reader;

        private readonly IWriter _writer;

        private readonly ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
        {
            this._commandInterpreter = commandInterpreter;
            this._writer = writer;
            this._reader = reader;
        }

        public void Run() => ExecuteCommands();

        private void ExecuteCommands()
        {
            while (true)
            {
                try
                {
                    string input = this._reader.ReadLine();

                    string result = this._commandInterpreter.Read(input);

                    this._writer.WriteLine(result);

                    this._writer.ColorReset();
                }
                catch (InvalidOperationException exception)
                {
                    this._writer.WriteLine(exception.Message);
                }
            }
        }
    }
}
