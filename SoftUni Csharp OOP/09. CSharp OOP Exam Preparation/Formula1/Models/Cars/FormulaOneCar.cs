namespace Formula1.Models.Cars
{
    using System;

    using Contracts;
    using Utilities;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string _model;

        private int _horsePower;

        private double _engineDisplacement;

        protected FormulaOneCar(string model, int horsePower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsePower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    ThrowArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                _model = value;
            }
        }

        public int Horsepower
        {
            get => _horsePower;
            private set
            {
                if (value < 900 || value > 1050)
                {
                    ThrowArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                _horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get => _engineDisplacement;
            private set
            {
                if (value < 1.6 || value > 2)
                {
                    ThrowArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                _engineDisplacement = value;
            }
        }

        private void ThrowArgumentException(string message) => throw new ArgumentException(message);

        public double RaceScoreCalculator(int laps) => EngineDisplacement / Horsepower * laps;
    }
}
