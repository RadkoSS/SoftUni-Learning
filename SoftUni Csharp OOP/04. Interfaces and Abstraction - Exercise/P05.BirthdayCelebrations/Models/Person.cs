namespace BorderControl.Models
{
    using Contracts;

    public class Person : Citizen, IPerson
    {
        public Person(string name, int age, string id) : base(id)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }
    }
}
