namespace Formula1.Repositories
{
    using System.Linq;
    
    using Models.Contracts;

    public class PilotRepository : Repository<IPilot>
    {
        public override IPilot FindByName(string name)
        {
            IPilot searchedPilot = this.Models.FirstOrDefault(pilot => pilot.FullName == name);

            return searchedPilot;
        }
    }
}
