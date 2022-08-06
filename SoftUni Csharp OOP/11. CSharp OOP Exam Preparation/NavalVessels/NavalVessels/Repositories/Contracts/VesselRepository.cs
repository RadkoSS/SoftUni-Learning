namespace NavalVessels.Repositories.Contracts
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> _models;

        public VesselRepository()
        {
            this._models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this._models as IReadOnlyCollection<IVessel>;

        public void Add(IVessel model) => this._models.Add(model);

        public bool Remove(IVessel model) => this._models.Remove(model);

        public IVessel FindByName(string name) => this._models.FirstOrDefault(vessel => vessel.Name == name);
    }
}
