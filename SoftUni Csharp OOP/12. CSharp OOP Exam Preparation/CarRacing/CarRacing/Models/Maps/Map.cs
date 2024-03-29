﻿namespace CarRacing.Models.Maps
{
    using Contracts;
    using Racers.Contracts;
    using Utilities.Messages;

    public class Map : IMap
    {
        private const double StrictBehaviorMultiplier = 1.2;
        private const double AggressiveBehaviorMultiplier = 1.1;

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username); 
            }

            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double firstRacerBehaviorMultiplier = racerOne.RacingBehavior == "strict" ? StrictBehaviorMultiplier : AggressiveBehaviorMultiplier;

            double secondRacerBehaviorMultiplier = racerTwo.RacingBehavior == "strict" ? StrictBehaviorMultiplier : AggressiveBehaviorMultiplier;

            double firstRacerChanceOfWinning =
                racerOne.Car.HorsePower * racerOne.DrivingExperience * firstRacerBehaviorMultiplier;

            double secondRacerChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondRacerBehaviorMultiplier;

            racerOne.Race();
            racerTwo.Race();

            if (firstRacerChanceOfWinning > secondRacerChanceOfWinning)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);

        }
    }
}
