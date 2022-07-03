namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = defaultConsumption;
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }
    }
}
