namespace Animals
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        private string name;

        private int age;

        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get
            {
                return name; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.Name), "Name must not be null, empty or white-space!");
                }
                name = value;
            }
        }

        public int Age
        {
            get 
            { 
                return age;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(this.Age), "Age must not be a negative number!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get 
            { 
                return gender;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this.Gender), "Gender must not be null, empty or white-space!");
                }
                gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var textOutput = new StringBuilder();

            textOutput.AppendLine(this.GetType().Name.ToString());

            textOutput.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            textOutput.Append(ProduceSound());

            return textOutput.ToString().TrimEnd();
        }
    }
}
