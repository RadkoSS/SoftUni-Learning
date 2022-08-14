namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly ICollection<IMilitaryUnit> _units;

        public UnitRepository()
        {
            this._units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this._units as IReadOnlyCollection<IMilitaryUnit>;

        public void AddItem(IMilitaryUnit model) => this._units.Add(model);

        public IMilitaryUnit FindByName(string name) => this._units.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            var itemToRemove = this._units.FirstOrDefault(x => x.GetType().Name == name);

            return this._units.Remove(itemToRemove);
        }
    }
}
