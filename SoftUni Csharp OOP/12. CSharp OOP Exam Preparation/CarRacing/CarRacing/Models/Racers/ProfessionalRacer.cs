namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const int DefaultRacingXp = 30;
        private const string DefaultRacingBehavior = "strict";
        private const int DefaultDrivingXpIncrease = 10;

        public ProfessionalRacer(string username, ICar car) 
            : base(username, DefaultRacingBehavior, DefaultRacingXp, car)
        {

        }

        public override void Race()
        {
            base.Race();

            this.DrivingExperience += DefaultDrivingXpIncrease;
        }
    }
}
