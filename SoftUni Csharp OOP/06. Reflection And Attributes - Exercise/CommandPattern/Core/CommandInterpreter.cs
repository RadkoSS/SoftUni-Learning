namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Common;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitedStrings = args.Split();

            string className = $"{splitedStrings[0]}Command";

            string[] cmdArgs = splitedStrings.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(type =>
                type.Name == className && type.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (commandType == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeOfCommandMessage, className));
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            MethodInfo method = commandType.GetMethods().First(method => method.Name == "Execute");

            string result = method.Invoke(command, new object[] { cmdArgs }) as string;

            return result;
        }
    }
}
