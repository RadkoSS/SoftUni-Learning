namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultConsumption = 3;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = defaultConsumption;
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }
    }
}
