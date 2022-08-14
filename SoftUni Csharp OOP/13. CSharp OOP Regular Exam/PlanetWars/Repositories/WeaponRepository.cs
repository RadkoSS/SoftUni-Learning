namespace PlanetWars.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> _weapons;

        public WeaponRepository()
        {
            this._weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this._weapons as IReadOnlyCollection<IWeapon>;

        public void AddItem(IWeapon model) => this._weapons.Add(model);

        public IWeapon FindByName(string name) => this._weapons.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            var itemToRemove = this._weapons.FirstOrDefault(x => x.GetType().Name == name);

            return this._weapons.Remove(itemToRemove);
        }
    }
}
