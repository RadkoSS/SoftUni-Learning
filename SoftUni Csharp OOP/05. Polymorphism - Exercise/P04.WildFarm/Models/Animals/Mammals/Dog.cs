namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;

    using Models.Food;

    public class Dog : Mammal
    {
        private const double DogWeightIncrease = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> { typeof(Meat) }.AsReadOnly();

        public override double WeightModifier => DogWeightIncrease;

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{base.ToString()} {base.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
