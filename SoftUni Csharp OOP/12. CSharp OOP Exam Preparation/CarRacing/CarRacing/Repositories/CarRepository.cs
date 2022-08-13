namespace CarRacing.Repositories
{
    using System.Linq;
    using Models.Cars.Contracts;

    public class CarRepository : Repository<ICar>
    {
        public override ICar FindBy(string property) => this.Models.FirstOrDefault(model => model.VIN == property);
    }
}
