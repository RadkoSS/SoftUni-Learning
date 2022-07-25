namespace FoodShortage.Models
{
    using Contracts;

    public class Citizen : Person, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        : base(name, age)
        {
            this.Id = id;
            this.BirthDate = birthDate;
            this.Food = 0;
        }

        public string Id { get; }

        public string BirthDate { get; }

        public int Food { get; private set; }

        public void BuyFood() => this.Food += 10;
    }
}
