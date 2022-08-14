namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> _planets;

        public PlanetRepository()
        {
            this._planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this._planets as IReadOnlyCollection<IPlanet>;

        public void AddItem(IPlanet model) => this._planets.Add(model);

        public IPlanet FindByName(string name) => this._planets.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name)
        {
            var itemToRemove = this._planets.FirstOrDefault(x => x.Name == name);

            return this._planets.Remove(itemToRemove);
        }
    }
}
