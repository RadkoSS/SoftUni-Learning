namespace P03_BarraksWars.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Globalization;

    using Utilities.Attributes;
    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

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

            IExecutable command = Activator.CreateInstance(commandType, (object) data) as IExecutable;

            InjectDependencies(ref command);

            return command;
        }

        private void InjectDependencies(ref IExecutable command)
        {
            FieldInfo[] commandFields = command.GetType().GetFields(Flags).Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null).ToArray();

            FieldInfo[] interpreterFields = this.GetType().GetFields(Flags);

            foreach (FieldInfo commandField in commandFields)
            {
                if (interpreterFields.Any(interpreterField => interpreterField.FieldType == commandField.FieldType))
                {
                    FieldInfo interpreterField = interpreterFields.First(interpreterField =>
                        interpreterField.FieldType == commandField.FieldType);

                    commandField.SetValue(command, interpreterField.GetValue(this));
                }
            }
        }
    }
}
