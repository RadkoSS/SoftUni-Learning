namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    
    using Models.Food;

    public class Cat : Feline
    {
        private const double CatWeightIncrease = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> { typeof(Vegetable), typeof(Meat) }.AsReadOnly();

        public override double WeightModifier => CatWeightIncrease;

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
