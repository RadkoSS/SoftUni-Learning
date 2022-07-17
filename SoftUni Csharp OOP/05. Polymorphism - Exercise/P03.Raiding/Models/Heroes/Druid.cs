namespace Raiding.Models.Heroes
{
    public class Druid : BaseHero
    {
        private const int DefaultPower = 80;

        public Druid(string name) : base(name, DefaultPower)
        {

        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
    }
}
