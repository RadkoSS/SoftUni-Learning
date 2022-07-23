namespace BirthdayCelebration.Models
{
    using Contracts;

    public class Person : Citizen, IPerson, IBirthtable
    {
        public Person(string name, int age, string id, string birthDate) : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthDate;
        }

        public string Name { get; }

        public int Age { get; }

        public string BirthDate { get; }
    }
}
