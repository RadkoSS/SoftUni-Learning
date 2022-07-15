namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;

    using Models.Food;

    public class Mouse : Mammal
    {
        private const double MouseWeightIncrease = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> { typeof(Vegetable), typeof(Fruit) }.AsReadOnly();

        public override double WeightModifier => MouseWeightIncrease;

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{base.ToString()} {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
