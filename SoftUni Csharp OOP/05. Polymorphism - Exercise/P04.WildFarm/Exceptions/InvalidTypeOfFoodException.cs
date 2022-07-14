namespace WildFarm.Exceptions
{
    using System;

    public class InvalidTypeOfFoodException : Exception
    {
        public InvalidTypeOfFoodException(string message) : base(message)
        {

        }
    }
}
