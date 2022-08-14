namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        public IReadOnlyCollection<IPlanet> Models => throw new NotImplementedException();

        public void AddItem(IPlanet model)
        {
            throw new NotImplementedException();
        }

        public IPlanet FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
