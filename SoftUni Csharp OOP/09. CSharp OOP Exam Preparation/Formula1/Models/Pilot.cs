namespace Formula1.Models
{
    using System;

    using Contracts;

    public class Pilot : IPilot
    {
        public Pilot(string fullName)
        {
            
        }

        public string FullName { get; private set; }

        public IFormulaOneCar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            throw new NotImplementedException();
        }

        public void WinRace()
        {
            throw new NotImplementedException();
        }
    }
}
