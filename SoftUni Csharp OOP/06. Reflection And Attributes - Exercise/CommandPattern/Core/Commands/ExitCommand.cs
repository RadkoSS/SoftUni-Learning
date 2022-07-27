namespace CommandPattern.Core.Commands
{
    using System;

    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            const int successfulExitMessage = 0;

            Environment.Exit(successfulExitMessage);

            return null;
        }
    }
}