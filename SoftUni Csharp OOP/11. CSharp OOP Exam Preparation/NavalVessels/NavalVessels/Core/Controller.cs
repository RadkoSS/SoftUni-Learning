namespace NavalVessels.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using Models.Contracts;
    using Utilities.Messages;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IVessel> _vesselRepository;

        private readonly ICollection<ICaptain> _captainCollection;

        public Controller()
        {
            this._vesselRepository = new VesselRepository();
            this._captainCollection = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = this._captainCollection.FirstOrDefault(captain => captain.FullName == fullName);

            if (captain != null)
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captain = new Captain(fullName);

            this._captainCollection.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this._vesselRepository.Models.FirstOrDefault(vessel => vessel.Name == name);

            if (vessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vessel.GetType().Name, name);
            }

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            this._vesselRepository.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vessel.GetType().Name, name,
                mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            IVessel selectedVessel = this._vesselRepository.FindByName(selectedVesselName);

            ICaptain selectedCaptain = this._captainCollection.FirstOrDefault(c => c.FullName == selectedCaptainName);

            bool hasCaptain = selectedVessel != null && selectedVessel.Captain != null;

            if (selectedCaptain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (selectedVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (hasCaptain)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            selectedCaptain.AddVessel(selectedVessel);

            selectedVessel.Captain = selectedCaptain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this._captainCollection.FirstOrDefault(c => c.FullName == captainFullName);

            return captain?.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this._vesselRepository.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this._vesselRepository.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel is Battleship ship)
            {
                ship.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            if (vessel is Submarine submarine)
            {
                submarine.ToggleSubmergeMode();
            }

            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this._vesselRepository.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this._vesselRepository.FindByName(attackingVesselName);

            IVessel defendingVessel = this._vesselRepository.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);

            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
                defendingVessel.ArmorThickness);
        }

    }
}
