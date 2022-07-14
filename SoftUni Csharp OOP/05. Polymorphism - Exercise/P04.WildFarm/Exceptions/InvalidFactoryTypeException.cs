namespace WildFarm.Exceptions
{
    using System;

    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultExceptionMsg = "Invalid type!";

        public InvalidFactoryTypeException() 
            : base(DefaultExceptionMsg)
        {

        }

        public InvalidFactoryTypeException(string message) 
            : base(message)
        {

        }
    }
}
