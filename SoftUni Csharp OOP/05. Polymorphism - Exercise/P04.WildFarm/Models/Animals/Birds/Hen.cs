namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;

    using Models.Food;

    public class Hen : Bird
    {
        private const double HenWeightIcrease = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override IReadOnlyCollection<Type> PrefferedFoods => new List<Type> { typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable) }.AsReadOnly();

        public override double WeightModifier => HenWeightIcrease;

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
