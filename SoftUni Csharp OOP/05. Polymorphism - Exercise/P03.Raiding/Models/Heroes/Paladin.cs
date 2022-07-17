namespace Raiding.Models.Heroes
{
    public class Paladin : BaseHero
    {
        private const int DefaultPower = 100;

        public Paladin(string name) : base(name, DefaultPower)
        {
        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
    }
}
