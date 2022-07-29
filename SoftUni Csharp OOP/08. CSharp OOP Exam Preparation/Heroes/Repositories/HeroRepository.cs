namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> _heroes;

        public HeroRepository()
        {
            this._heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this._heroes as IReadOnlyCollection<IHero>;

        public void Add(IHero model) => this._heroes.Add(model);

        public bool Remove(IHero model) => this._heroes.Remove(model);

        public IHero FindByName(string name)
        {
            IHero searchedHero = this._heroes.FirstOrDefault(hero => hero.Name == name);

            return searchedHero;
        }
    }
}
