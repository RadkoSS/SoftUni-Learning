namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TunedCar : Car
    {
        private const double DefaultStartingFuel = 65;
        private const double DefaultFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, DefaultStartingFuel, DefaultFuelConsumptionPerRace)
        {

        }

        public override void Drive()
        {
            base.Drive();

            int hpAfterEngineWear = (int) Math.Round(this.HorsePower * 0.97);

            this.HorsePower = hpAfterEngineWear;
        }
    }
}
