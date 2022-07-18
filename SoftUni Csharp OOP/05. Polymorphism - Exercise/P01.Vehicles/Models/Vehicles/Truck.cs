namespace Vehicles.Models.Vehicles
{ 
    public class Truck : Vehicle
    {
        private const double TruckFuelLoss = 0.95;
        private const double TruckFuelModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumptionModifier => TruckFuelModifier;

        public override void Refuel(double litersOfFuel)
        {
            base.Refuel(litersOfFuel * TruckFuelLoss);
        }
    }
}
