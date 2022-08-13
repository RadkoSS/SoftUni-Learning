namespace CarRacing.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Cars;
    using Models.Maps;
    using Repositories;
    using Models.Racers;
    using Utilities.Messages;
    using Models.Cars.Contracts;
    using Models.Maps.Contracts;
    using Repositories.Contracts;
    using Models.Racers.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<ICar> _carsRepository;
        private readonly IRepository<IRacer> _racerRepository;
        private readonly IMap _map;

        public Controller()
        {
            this._carsRepository = new CarRepository();
            this._racerRepository = new RacerRepository();
            this._map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = type switch
            {
                nameof(SuperCar) => new SuperCar(make, model, VIN, horsePower),

                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),

                _ => throw new ArgumentException(ExceptionMessages.InvalidCarType)
            };

            this._carsRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar wantedCar = this._carsRepository.FindBy(carVIN);

            if (wantedCar == null)
            {
                ThrowArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, wantedCar),

                nameof(StreetRacer) => new StreetRacer(username, wantedCar),

                _ => throw new ArgumentException(ExceptionMessages.InvalidRacerType)
            };

            this._racerRepository.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = this._racerRepository.FindBy(racerOneUsername);

            if (firstRacer == null)
            {
                ThrowArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            IRacer secondRacer = this._racerRepository.FindBy(racerTwoUsername);

            if (secondRacer == null)
            {
                ThrowArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this._map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            StringBuilder reportText = new StringBuilder();

            List<IRacer> racerList = this._racerRepository.Models.ToList().OrderByDescending(racer => racer.DrivingExperience).ThenBy(racer => racer.Username).ToList();

            foreach (var racer in racerList)
            {
                reportText.AppendLine(racer.ToString());
            }

            return reportText.ToString().TrimEnd();
        }

        private static void ThrowArgumentException(string message) => throw new ArgumentException(message);
    }
}
