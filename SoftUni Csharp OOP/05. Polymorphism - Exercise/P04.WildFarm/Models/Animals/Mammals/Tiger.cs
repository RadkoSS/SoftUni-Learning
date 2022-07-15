namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;

    using Models.Food;

    public class Tiger : Feline
    {
        private const double TigerWeightIncrease = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> { typeof(Meat) }.AsReadOnly();

        public override double WeightModifier => TigerWeightIncrease;

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
