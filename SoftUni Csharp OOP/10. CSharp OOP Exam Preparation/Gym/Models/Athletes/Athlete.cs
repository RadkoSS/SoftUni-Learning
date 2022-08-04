namespace Gym.Models.Athletes
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Athlete : IAthlete
    {
        private string _fullName;

        private string _motivation;

        private int _numberOfMeals;

        private int _stamina;

        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get => _fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ThrowArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                this._fullName = value;
            }
        }

        public string Motivation
        {
            get => _motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    ThrowArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                this._motivation = value;
            }
        }

        public int Stamina
        {
            get => this._stamina;
            protected set
            {
                if (value > 100)
                {
                    this._stamina = 100;

                    ThrowArgumentException(ExceptionMessages.InvalidStamina);
                }

                this._stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get => this._numberOfMeals;
            private set
            {
                if (value < 0)
                {
                    ThrowArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                this._numberOfMeals = value;
            }
        }

        private static void ThrowArgumentException(string message) => throw new ArgumentException(message);

        public abstract void Exercise();
    }
}
