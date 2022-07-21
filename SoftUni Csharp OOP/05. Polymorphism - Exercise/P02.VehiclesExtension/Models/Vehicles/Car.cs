namespace VehiclesExtension.Models.Vehicles
{
    public class Car : Vehicle
    {
        private const double CarFuelModifier = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double ModifiedFuelConsumption => base.FuelConsumption + CarFuelModifier;
    }
}
