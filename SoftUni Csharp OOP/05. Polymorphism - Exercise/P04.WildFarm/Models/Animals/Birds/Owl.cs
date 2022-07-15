namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using WildFarm.Models.Food;
    using WildFarm.Models.Animals.Birds;

    public class Owl : Bird
    {
        private const double OwlWeightIncrease = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> { typeof(Meat) }.AsReadOnly();

        public override double WeightModifier => OwlWeightIncrease;

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
