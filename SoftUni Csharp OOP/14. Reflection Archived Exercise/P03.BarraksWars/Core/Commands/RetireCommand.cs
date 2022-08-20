namespace P03_BarraksWars.Core.Commands
{
    using Utilities.Attributes;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public RetireCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            this.repository.RemoveUnit(this.Data[1]);
            return $"{this.Data[1]} retired!";
        }
    }
}
