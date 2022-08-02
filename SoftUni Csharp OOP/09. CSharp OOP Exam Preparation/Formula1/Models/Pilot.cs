namespace Formula1.Models
{
    using System;

    using Contracts;
    using Utilities;

    public class Pilot : IPilot
    {
        private string _fullName;

        private IFormulaOneCar _car;

        private Pilot() => this.CanRace = false;

        public Pilot(string fullName) : this()
        {
            this.FullName = fullName;
        }

        public string FullName
        {
            get => this._fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    ThrowArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                this._fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this._car;
            set
            {
                if (value == null)
                {
                    ThrowNullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                this._car = value;
            }
        }

        public int NumberOfWins { get; private set; }


        public bool CanRace { get; private set; }


        private void ThrowNullReferenceException(string message) => throw new NullReferenceException(message);


        private void ThrowArgumentException(string message) => throw new ArgumentException(message);


        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;

            this.CanRace = true;
        }

        public void WinRace() => this.NumberOfWins++;

        public override string ToString() => $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
    }
}
