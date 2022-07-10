namespace PersonInfo
{
    using System;

    public class Citizen : IPerson
    {
        private string name;

        private int age;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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

        public override string ToString()
        {
            return $"{this.Name} is {this.Age}yo.";
        }
    }
}
