namespace BirthdayCelebration.Models
{
    public abstract class Citizen
    {
        protected Citizen(string id)
        {
            this.Id = id;
        }

        public string Id { get; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
