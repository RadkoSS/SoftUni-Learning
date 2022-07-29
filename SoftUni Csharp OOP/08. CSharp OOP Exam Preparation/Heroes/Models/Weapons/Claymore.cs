﻿namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int Damage = 20;

        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (base.Durability == 0)
            {
                return 0;
            }

            base.Durability--;

            return Damage;
        }
    }
}
