namespace CarRacing.Repositories
{
    using System.Linq;
    using Models.Racers.Contracts;

    public class RacerRepository : Repository<IRacer>
    {
        public override IRacer FindBy(string property) => this.Models.FirstOrDefault(model => model.Username == property);
    }
}
