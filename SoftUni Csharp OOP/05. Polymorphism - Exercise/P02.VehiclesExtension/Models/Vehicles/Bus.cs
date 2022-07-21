namespace VehiclesExtension.Models.Vehicles
{
    public class Bus : Vehicle
    {
        private const double BusWithPeopleFuelModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        protected override double ModifiedFuelConsumption => base.FuelConsumption + BusWithPeopleFuelModifier;
    }
}
