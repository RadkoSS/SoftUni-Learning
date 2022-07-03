namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultConsumption = 1.25;

        private double fuelConsumption;

        private int horsePower;

        private double fuel;

        public double DefaultFuelConsumption => defaultConsumption;

        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public int HorsePower 
        { 
            get { return horsePower; }
            set { horsePower = value; }
        }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public virtual void Drive(double kilometers) => this.Fuel -= kilometers * this.FuelConsumption;
    }
}
