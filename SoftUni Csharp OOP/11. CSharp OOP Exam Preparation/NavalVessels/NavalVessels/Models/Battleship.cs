namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const int InitialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(base.ToString());
            output.AppendLine($" *Sonar mode: {(this.SonarMode ? "ON" : "OFF")}");

            return output.ToString().TrimEnd();
        }
    }
}
