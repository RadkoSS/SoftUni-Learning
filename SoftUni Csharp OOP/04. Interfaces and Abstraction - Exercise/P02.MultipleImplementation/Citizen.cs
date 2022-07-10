namespace PersonInfo
{
    using System;

    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private string name;

        private int age;

        private string id;

        private string birthDate;

        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthDate;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{nameof(this.Name)} Name cannot be null, empty or whitespace.");
                }
                this.name = value;
            }

        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new Exception($"{nameof(this.Age)} Age cannot be zero or a negative number.");
                }
                this.age = value;
            }

        }

        public string Birthdate 
        {
            get => this.birthDate;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{nameof(this.Birthdate)} Birth date cannot be null, empty or whitespace.");
                }

                this.birthDate = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"{nameof(this.Id)} Birth date cannot be null, empty or whitespace.");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} is {this.Age}yo. Their birthday is {this.Birthdate} and their personal ID is {this.Id}.";
        }
    }
}
