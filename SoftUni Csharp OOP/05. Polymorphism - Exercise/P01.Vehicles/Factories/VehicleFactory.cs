namespace Vehicles.Factories
{
    using Models;
    using Models.Vehicles;

    using Exceptions;
    using Interfaces;

    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidVehicleException();
            }

            return vehicle;
        }
    }
}
