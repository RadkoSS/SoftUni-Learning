namespace Vehicles.Exceptions
{
    using System;

    public class InvalidVehicleException : Exception
    {
        private const string DefaultMessage = "Invalid vehicle!";

        public InvalidVehicleException() : base(DefaultMessage)
        {
            
        }

        public InvalidVehicleException(string message) : base(message)
        {
            
        }
    }
}
