namespace WildFarm.Models.Animals.Mammals
{
    using System;

    using Exceptions.ExceptionMessages;

    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get
            {
                return this.livingRegion;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessage.StringIsNullEmptyOrWhitespacesMsg, nameof(LivingRegion)));
                }

                this.livingRegion = value;
            }
        }

    }
}
