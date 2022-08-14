namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        public IReadOnlyCollection<IMilitaryUnit> Models => throw new NotImplementedException();

        public void AddItem(IMilitaryUnit model)
        {
            throw new NotImplementedException();
        }

        public IMilitaryUnit FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
