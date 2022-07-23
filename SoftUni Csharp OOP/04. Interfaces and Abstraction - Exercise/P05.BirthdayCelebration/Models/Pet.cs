namespace BirthdayCelebration.Models
{
    using Contracts;

    public class Pet : IBirthtable
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; }

        public string BirthDate { get; }
    }
}
