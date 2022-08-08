namespace CarRacing.Models.Racers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int DefaultRacingXp = 30;
        private const string DefaultRacingBehavior = "strict";

        public ProfessionalRacer(string username, ICar car) : base(username, DefaultRacingBehavior, DefaultRacingXp, car)
        {
        }
    }
}
