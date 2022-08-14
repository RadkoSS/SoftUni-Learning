namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double WeaponPrice = 15;

        public NuclearWeapon(int destructionLevel) : base(destructionLevel, WeaponPrice)
        {
        }
    }
}
