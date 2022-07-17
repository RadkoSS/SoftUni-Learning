namespace Raiding.Exceptions
{
    using System;

    public class InvalidHeroException : Exception
    {
        private const string Message = "Invalid hero!";

        public InvalidHeroException() : base(Message)
        {  

        }

        public InvalidHeroException(string message) : base (message)
        {
            
        }
    }
}
