namespace Heroes.Utilities.Exceptions
{
    public static class ExceptionMessages
    {
        public const string WeaponTypeIsNull = "Weapon type cannot be null or empty.";

        public const string DurabilityIsBelowZero = "Durability cannot be below 0.";

        public const string HeroNameIsNull = "Hero name cannot be null or empty.";

        public const string HeroHealthIsBelowZero = "Hero health cannot be below 0.";

        public const string HeroArmourIsBelowZero = "Hero armour cannot be below 0.";

        public const string WeaponInstanceIsNull = "Weapon cannot be null.";

        public const string HeroWithGivenNameExists = "The hero {0} already exists.";

        public const string HeroTypeIsInvalid = "Invalid hero type.";

        public const string WeaponWithGivenNameExists = "The weapon {0} already exists.";

        public const string WeaponTypeIsInvalid = "Invalid weapon type.";

        public const string HeroWithGivenNameDoesNotExist = "Hero {0} does not exist.";

        public const string WeaponWithGivenNameDoesNotExist = "Weapon {0} does not exist.";

        public const string HeroAlreadyHasWeapon = "Hero {0} is well-armed.";
    }
}
