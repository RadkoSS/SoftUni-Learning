namespace P03_BarraksWars.Models.Units
{
    using _03BarracksFactory.Models.Units;

    public class Horseman : Unit
    {
        private const int DefaultHealth = 50;

        private const int Attack = 10;

        public Horseman() : base(DefaultHealth, Attack)
        {
        }
    }
}
