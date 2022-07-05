namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private decimal? salary;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = null;
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName 
        { 
            get { return firstName; } 
            private set 
            {
                firstName = BasicNameValidation(value);
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set 
            { 
                lastName = BasicNameValidation(value);
            }
        }

        public int Age 
        { 
            get { return age; }
            private set 
            {
                if (value <= 0)
                {
                    throw new Exception("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }

        public decimal? Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {

                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }

                salary = value;
            }
        }

        private string BasicNameValidation(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Invalid name.");
            }
            else if (name.Length < 3)
            {
                throw new Exception("Name must be at least 3 symbols.");
            }
            return name;
        } 

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
