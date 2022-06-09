namespace SpeedRacing
{

    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumption;

        private double distanceTravelled;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;

            this.FuelAmount = fuelAmount;

            this.FuelConsumption = fuelConsumption;

            this.DistanceTravelled = 0;

        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double DistanceTravelled
        {
            get { return distanceTravelled; }
            set { distanceTravelled = value; }
        }

        public bool IsFuelEnough(double driveDistance) => fuelConsumption * driveDistance <= FuelAmount;

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.DistanceTravelled}";
        }
    }
}
