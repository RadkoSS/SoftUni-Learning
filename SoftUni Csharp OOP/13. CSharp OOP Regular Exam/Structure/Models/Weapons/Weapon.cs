namespace PlanetWars.Models.Weapons
{
    using System;
    
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(int destructionLevel, double price)
        {

        }

        public double Price => throw new NotImplementedException();

        public int DestructionLevel => throw new NotImplementedException();
    }
}
