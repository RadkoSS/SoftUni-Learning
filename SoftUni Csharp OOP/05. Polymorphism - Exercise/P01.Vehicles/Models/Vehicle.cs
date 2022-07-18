namespace Vehicles.Models
{
    using System;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double _fuelQuantity;

        private double _fuelConsumption;


        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => this._fuelQuantity;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.FuelQuantity)} cannot be a negative number!");
                }

                this._fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => this._fuelConsumption;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.FuelConsumption)} cannot be a negative number!");
                }

                this._fuelConsumption = value + this.FuelConsumptionModifier;
            }
        }

        public abstract double FuelConsumptionModifier { get; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double litersOfFuel) => this.FuelQuantity += litersOfFuel;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
