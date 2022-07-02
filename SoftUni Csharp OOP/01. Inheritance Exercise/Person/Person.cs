namespace Person
{
    public class Person
    {
        private string _name;

        private int age;

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    age = 0;

                else
                    age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
