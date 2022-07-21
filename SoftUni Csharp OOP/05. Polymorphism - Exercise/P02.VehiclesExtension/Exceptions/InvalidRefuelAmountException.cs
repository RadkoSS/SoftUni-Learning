namespace VehiclesExtension.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidRefuelAmountException : Exception
    {
        private const string DefaultMessage = "Fuel must be a positive number";

        public InvalidRefuelAmountException() : base(DefaultMessage)
        {
            
        }
    }
}
