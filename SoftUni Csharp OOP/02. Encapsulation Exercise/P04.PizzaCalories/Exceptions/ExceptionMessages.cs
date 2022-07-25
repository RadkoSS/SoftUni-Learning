namespace PizzaCalories.Exceptions
{
    public static class ExceptionMessages
    {
        public const string WeightExceptionMessage = "{0} weight should be in the range [1..200].";

        public const string ToppingWeightExceptionMessage = "{0} weight should be in the range [1..50].";

        public const string ToppingExceptionMessage = "Cannot place {0} on top of your pizza.";

        public const string DoughExceptionMessage = "Invalid type of dough.";

        public const string PizzaNameExceptionMessage = "Pizza name should be between 1 and 15 symbols.";

        public const string ToppingsOutOfRangeMessage = "Number of toppings should be in range [0..10].";
    }
}
