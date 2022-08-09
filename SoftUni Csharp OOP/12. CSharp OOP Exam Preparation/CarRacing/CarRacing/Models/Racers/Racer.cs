namespace CarRacing.Models.Racers
{
    using System;
    
    using Contracts;
    using Cars.Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private string _userName;

        private string _racingBehavior;

        private int _drivingExperience;

        private ICar _car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;
        }

        public string Username
        {
            get => this._userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowArgumentException(ExceptionMessages.InvalidRacerName);
                }

                this._userName = value;
            }
        }

        public string RacingBehavior
        {
            get => this._racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    ThrowArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                this._racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => this._drivingExperience;
            protected set
            {
                if (value < 0 || value > 100)
                {
                    ThrowArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                this._drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => this._car;
            private set
            {
                if (value == null)
                {
                    ThrowArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                this._car = value;
            }
        }

        public virtual void Race()
        {
            this.Car.Drive();
        }

        public bool IsAvailable() => this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace;

        private static void ThrowArgumentException(string message) => throw new ArgumentException(message);
    }
}
