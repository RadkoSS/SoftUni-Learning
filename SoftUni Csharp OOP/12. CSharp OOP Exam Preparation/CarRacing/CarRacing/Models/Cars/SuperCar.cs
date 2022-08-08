namespace CarRacing.Models.Cars
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class SuperCar : Car
    {
        private const double DefaultStartingFuel = 80;
        private const double DefaultFuelConsumptionPerRace = 10;

        public SuperCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, DefaultStartingFuel, DefaultFuelConsumptionPerRace)
        {

        }
    }
}
