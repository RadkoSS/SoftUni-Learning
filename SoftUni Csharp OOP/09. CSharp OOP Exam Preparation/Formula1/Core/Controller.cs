namespace Formula1.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Diagnostics;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using Utilities;
    using Models.Cars;
    using Repositories;
    using Models.Contracts;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IPilot> _pilots;

        private readonly IRepository<IRace> _races;

        private readonly IRepository<IFormulaOneCar> _cars;

        public Controller()
        {
            this._pilots = new PilotRepository();
            this._races = new RaceRepository();
            this._cars = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot searchedPilot = this._pilots.FindByName(fullName);

            if (searchedPilot != null)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            searchedPilot = new Pilot(fullName);

            this._pilots.Add(searchedPilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this._cars.FindByName(model);

            if (car != null)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this._cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace searchedRace = this._races.FindByName(raceName);

            if (searchedRace != null)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            searchedRace = new Race(raceName, numberOfLaps);

            this._races.Add(searchedRace);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot searchedPilot = this._pilots.FindByName(pilotName);

            IFormulaOneCar searchedCar = this._cars.FindByName(carModel);

            if (searchedPilot == null || searchedPilot.Car != null)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (searchedCar == null)
            {
                ThrowNullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            searchedPilot?.AddCar(searchedCar);

            this._cars.Remove(searchedCar);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, searchedCar?.GetType().Name,
                carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace searchedRace = this._races.FindByName(raceName);

            IPilot searchedPilot = this._pilots.FindByName(pilotFullName);

            if (searchedRace == null)
            {
                ThrowNullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (searchedPilot == null || !searchedPilot.CanRace || searchedRace.Pilots.Contains(searchedPilot))
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            searchedRace?.AddPilot(searchedPilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            IRace searchedRace = this._races.FindByName(raceName);

            if (searchedRace == null)
            {
                ThrowNullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (searchedRace?.Pilots.Count < 3)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (searchedRace.TookPlace)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilotsList = searchedRace.Pilots as List<IPilot>;

            List<IPilot> arrangedPilots = pilotsList.OrderByDescending(pilot => pilot.Car.RaceScoreCalculator(searchedRace.NumberOfLaps)).ToList();

            searchedRace.TookPlace = true;

            IPilot firstWinner = arrangedPilots[0];
            IPilot secondWinner = arrangedPilots[1];
            IPilot thirdWinner = arrangedPilots[2];

            firstWinner.WinRace();

            StringBuilder output = new StringBuilder();

            output.AppendLine($"Pilot {firstWinner.FullName} wins the {searchedRace.RaceName} race.");
            output.AppendLine($"Pilot {secondWinner.FullName} is second in the {searchedRace.RaceName} race.");
            output.AppendLine($"Pilot {thirdWinner.FullName} is third in the {searchedRace.RaceName} race.");

            return output.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            List<IRace> racesList = this._races.Models as List<IRace>;

            List<string> executedRaces = racesList.FindAll(race => race.TookPlace).Select(race => race.RaceInfo()).ToList();

            return string.Join(Environment.NewLine, executedRaces);
        }

        public string PilotReport()
        {
            List<IPilot> pilotsList = this._pilots.Models as List<IPilot>;

            List<IPilot> orderedList = pilotsList.OrderByDescending(pilot => pilot.NumberOfWins).ToList();

            return string.Join(Environment.NewLine, orderedList);
        }

        private void ThrowInvalidOperationException(string message) => throw new ArgumentException(message);

        private void ThrowNullReferenceException(string message) => throw new NullReferenceException(message);
    }
}
