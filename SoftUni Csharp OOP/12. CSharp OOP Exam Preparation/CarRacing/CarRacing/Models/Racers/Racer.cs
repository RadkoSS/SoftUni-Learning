namespace CarRacing.Models.Racers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cars.Contracts;
    using Contracts;

    public abstract class Racer : IRacer
    {
        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            
        }

        public string Username => throw new NotImplementedException();

        public string RacingBehavior => throw new NotImplementedException();

        public int DrivingExperience => throw new NotImplementedException();

        public ICar Car => throw new NotImplementedException();

        public void Race()
        {
            throw new NotImplementedException();
        }

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
