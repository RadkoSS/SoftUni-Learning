namespace Vehicles.Models.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarFuelModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumptionModifier => CarFuelModifier;
    }
}
