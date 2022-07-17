namespace Raiding.Models.Heroes
{
    public class Rogue : BaseHero
    {
        private const int DefaultPower = 80;

        public Rogue(string name) : base(name, DefaultPower)
        {
        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
