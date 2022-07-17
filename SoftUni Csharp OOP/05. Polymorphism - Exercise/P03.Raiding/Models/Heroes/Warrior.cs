namespace Raiding.Models.Heroes
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;

        public Warrior(string name) : base(name, DefaultPower)
        {

        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
