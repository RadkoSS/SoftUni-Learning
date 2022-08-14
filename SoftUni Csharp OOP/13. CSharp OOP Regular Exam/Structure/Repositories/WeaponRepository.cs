namespace PlanetWars.Repositories
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        public IReadOnlyCollection<IWeapon> Models => throw new NotImplementedException();

        public void AddItem(IWeapon model)
        {
            throw new NotImplementedException();
        }

        public IWeapon FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
