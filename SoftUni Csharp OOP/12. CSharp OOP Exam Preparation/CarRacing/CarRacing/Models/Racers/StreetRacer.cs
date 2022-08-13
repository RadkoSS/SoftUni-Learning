namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const int DefaultRacingXp = 10;
        private const string DefaultRacingBehavior = "aggressive";
        private const int DefaultDrivingXpIncrease = 5;

        public StreetRacer(string username, ICar car) 
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
