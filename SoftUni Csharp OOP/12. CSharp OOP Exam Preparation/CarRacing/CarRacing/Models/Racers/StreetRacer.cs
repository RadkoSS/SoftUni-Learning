namespace CarRacing.Models.Racers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int DefaultRacingXp = 10;
        private const string DefaultRacingBehavior = "aggressive";

        public StreetRacer(string username, ICar car) : base(username, DefaultRacingBehavior, DefaultRacingXp, car)
        {

        }
    }
}
