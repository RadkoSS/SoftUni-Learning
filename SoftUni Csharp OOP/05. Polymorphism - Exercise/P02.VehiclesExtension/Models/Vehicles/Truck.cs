namespace VehiclesExtension.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TruckFuelLoss = 0.95;
        private const double TruckFuelModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        protected override double ModifiedFuelConsumption => base.FuelConsumption + TruckFuelModifier;

        public override bool Refuel(double litersOfFuel) => base.Refuel(litersOfFuel * TruckFuelLoss);

    }
}
