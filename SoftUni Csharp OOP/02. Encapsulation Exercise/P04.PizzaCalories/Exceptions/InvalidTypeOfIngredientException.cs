namespace PizzaCalories.Exceptions
{
    using System;

    public class InvalidTypeOfIngredientException : Exception
    {

        public InvalidTypeOfIngredientException(string message)
        : base(message)
        {

        }
    }
}
