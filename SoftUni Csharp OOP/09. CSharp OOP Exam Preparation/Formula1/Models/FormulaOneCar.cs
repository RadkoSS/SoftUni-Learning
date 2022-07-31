namespace Formula1.Models
{
    using System;

    using Contracts;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        protected FormulaOneCar(string model, int horsePower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsePower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model { get; private set; }

        public int Horsepower { get; private set; }

        public double EngineDisplacement { get; private set; }

        public double RaceScoreCalculator(int laps)
        {
            throw new NotImplementedException();
        }
    }
}
