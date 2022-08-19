namespace P03_BarraksWars.Models.Units
{
    using _03BarracksFactory.Models.Units;

    public class Gunner : Unit
    {
        private const int DefaultHealth = 20;

        private const int Attack = 20;

        public Gunner() : base(DefaultHealth, Attack)
        {
        }
    }
}
