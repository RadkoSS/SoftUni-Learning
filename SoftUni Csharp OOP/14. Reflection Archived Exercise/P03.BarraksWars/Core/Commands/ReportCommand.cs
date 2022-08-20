namespace P03_BarraksWars.Core.Commands
{
    using Utilities.Attributes;
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public ReportCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute() => this.repository.Statistics;
    }
}
