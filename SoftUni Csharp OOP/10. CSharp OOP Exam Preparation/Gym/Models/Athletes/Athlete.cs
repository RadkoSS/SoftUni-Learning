namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public abstract class Athlete : IAthlete
    {
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {

        }

        public string FullName => throw new NotImplementedException();
        public string Motivation => throw new NotImplementedException();
        public int Stamina => throw new NotImplementedException();
        public int NumberOfMedals => throw new NotImplementedException();

        public abstract void Exercise();
    }
}
