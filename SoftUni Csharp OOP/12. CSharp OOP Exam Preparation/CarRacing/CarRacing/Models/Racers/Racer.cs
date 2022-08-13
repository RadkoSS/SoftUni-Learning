namespace CarRacing.Models.Racers
{
    using System;
    using System.Text;
    using Contracts;
    using Cars.Contracts;
    using Utilities.Messages;

    public abstract class Racer : IRacer
    {
        private const int MinimalDrivingXp = 0;
        private const int MaximalDrivingXp = 100;

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
                if (value < MinimalDrivingXp || value > MaximalDrivingXp)
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

        public virtual void Race() => this.Car.Drive();

        public bool IsAvailable() => this.Car.FuelAvailable >= this.Car.FuelConsumptionPerRace;

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{this.GetType().Name}: {this.Username}");
            output.AppendLine($"--Driving behavior: {this.RacingBehavior}");
            output.AppendLine($"--Driving experience: {this.DrivingExperience}");
            output.AppendLine($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");

            return output.ToString().TrimEnd();
        }

        private static void ThrowArgumentException(string message) => throw new ArgumentException(message);
    }
}
