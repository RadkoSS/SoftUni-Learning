namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const int InitialArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString());
            output.AppendLine($" *Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}");

            return output.ToString().TrimEnd();
        }
    }
}
