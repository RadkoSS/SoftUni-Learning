namespace P03_BarraksWars.Core.Commands
{
    using System;

    public class FightCommand : Command
    {
        private const int ExitCodeSuccessful = 0;

        public FightCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(ExitCodeSuccessful);

            return null;
        }
    }
}
