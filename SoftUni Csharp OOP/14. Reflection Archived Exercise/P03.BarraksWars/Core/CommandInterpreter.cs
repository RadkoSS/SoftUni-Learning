namespace P03_BarraksWars.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Globalization;

    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private readonly IRepository repository;

        private readonly IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string fullName = $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName)}{CommandSuffix}";

            Type commandType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(type => type.Name == fullName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            IExecutable command = Activator.CreateInstance(commandType, data, this.repository, this.unitFactory) as IExecutable;

            return command;
        }
    }
}
