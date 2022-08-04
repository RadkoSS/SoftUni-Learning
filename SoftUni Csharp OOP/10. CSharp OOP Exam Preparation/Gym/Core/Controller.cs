namespace Gym.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Gyms;
    using Repositories;
    using Models.Athletes;
    using Models.Equipment;
    using Utilities.Messages;
    using Models.Gyms.Contracts;
    using Repositories.Contracts;
    using Models.Athletes.Contracts;
    using Models.Equipment.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IEquipment> _equipmentRepository;

        private readonly ICollection<IGym> _gymsCollection;

        public Controller()
        {
            this._equipmentRepository = new EquipmentRepository();
            this._gymsCollection = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                ThrowInvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this._gymsCollection.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                ThrowInvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this._equipmentRepository.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment wantedEquipment = this._equipmentRepository.FindByType(equipmentType);

            if (wantedEquipment == null)
            {
                ThrowInvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            this._gymsCollection.FirstOrDefault(gym => gym.Name == gymName)?.AddEquipment(wantedEquipment);

            this._equipmentRepository.Remove(wantedEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this._gymsCollection.FirstOrDefault(gym => gym.Name == gymName);

            IAthlete athlete = null;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym?.GetType().Name != "BoxingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);

                if (gym?.GetType().Name != "WeightliftingGym")
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                ThrowInvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            gym?.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this._gymsCollection.FirstOrDefault(gym => gym.Name == gymName);

            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName) => string.Format(OutputMessages.EquipmentTotalWeight, gymName, this._gymsCollection.FirstOrDefault(gym => gym.Name == gymName)?.EquipmentWeight);

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var gym in this._gymsCollection)
            {
                report.AppendLine(gym.GymInfo());
            }

            return report.ToString().TrimEnd();
        }

        private static void ThrowInvalidOperationException(string message) =>
            throw new InvalidOperationException(message);
    }
}
