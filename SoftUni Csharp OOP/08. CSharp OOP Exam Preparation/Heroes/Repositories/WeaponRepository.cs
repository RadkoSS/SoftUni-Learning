namespace Heroes.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> _weapons;

        public WeaponRepository()
        {
            this._weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this._weapons as IReadOnlyCollection<IWeapon>;

        public void Add(IWeapon model) => this._weapons.Add(model);

        public bool Remove(IWeapon model) => this._weapons.Remove(model);

        public IWeapon FindByName(string name)
        {
            IWeapon searchedWeapon = this._weapons.FirstOrDefault(weapon => weapon.Name == name);

            return searchedWeapon;
        }
    }
}
