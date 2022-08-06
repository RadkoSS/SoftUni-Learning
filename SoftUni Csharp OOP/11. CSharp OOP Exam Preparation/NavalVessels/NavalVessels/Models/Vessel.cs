namespace NavalVessels.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string _name;

        private ICaptain _captain;

        protected Vessel()
        {
            this.Targets = new List<string>();
        }

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness) : this()
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this._name = value;
            }
        }

        public ICaptain Captain
        {
            get => this._captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this._captain = value;
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; set; }

        public double Speed { get; set; }

        public ICollection<string> Targets { get; set; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            if (target.ArmorThickness - this.MainWeaponCaliber < 0)
            {
                target.ArmorThickness = 0;
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
            }

            this.Targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            string vesselType = this.GetType().Name;

            if (vesselType == "Submarine")
            {
                this.ArmorThickness = 200;
            }
            else if (vesselType == "Battleship")
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string targetsList = this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None";

            output.AppendLine($"- {this.Name}");
            output.AppendLine($" *Type: {this.GetType().Name}");
            output.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            output.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            output.AppendLine($" *Speed: {this.Speed} knots");
            output.Append($" *Targets: {targetsList}");

            return output.ToString();
        }
    }
}
