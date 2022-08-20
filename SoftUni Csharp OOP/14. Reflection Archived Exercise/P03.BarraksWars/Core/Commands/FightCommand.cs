namespace P03_BarraksWars.Core.Commands
{
    using System;

    using _03BarracksFactory.Contracts;

    public class FightCommand : Command
    {
        private const int ExitCodeSuccessful = 0;

        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(ExitCodeSuccessful);

            return null;
        }
    }
}
