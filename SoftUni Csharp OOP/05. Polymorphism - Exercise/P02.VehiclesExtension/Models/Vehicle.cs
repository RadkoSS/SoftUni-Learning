using VehiclesExtension.Exceptions;

namespace VehiclesExtension.Models
{
    using System;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double _fuelQuantity;

        private double _fuelConsumption;

        private double _tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
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
                if (value > this.TankCapacity)
                {
                    this._fuelQuantity = 0;
                }
                else
                {
                    this._fuelQuantity = value;
                }
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

                this._fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => this._tankCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.TankCapacity)} cannot be a negative number!");
                }

                this._tankCapacity = value;
            }
        }

        protected abstract double ModifiedFuelConsumption { get; }

        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.ModifiedFuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual bool Refuel(double litersOfFuel)
        {
            if (litersOfFuel <= 0)
            {
                throw new InvalidRefuelAmountException();
            }

            if (litersOfFuel > this.TankCapacity - this.FuelQuantity)
            {
                return false;
            }

            this.FuelQuantity += litersOfFuel;
            return true;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
