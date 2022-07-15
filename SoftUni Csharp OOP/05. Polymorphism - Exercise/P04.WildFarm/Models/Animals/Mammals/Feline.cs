namespace WildFarm.Models.Animals.Mammals
{
    using System;

    using Exceptions.ExceptionMessages;

    public abstract class Feline : Mammal
    {
        private string breed;

        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get
            {
                return this.breed;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessage.StringIsNullEmptyOrWhitespacesMsg, nameof(Breed)));
                }

                this.breed = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Breed}, {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
