namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int DefaultStamina = 50;

        private const int DefaultStaminaIncrease = 10;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, DefaultStamina)
        {
        }

        public override void Exercise() => this.Stamina += DefaultStaminaIncrease;
    }
}
