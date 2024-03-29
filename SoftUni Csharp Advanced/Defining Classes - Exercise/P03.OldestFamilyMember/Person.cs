﻿namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person() : this("No name", 1)
        {

        }

        public Person(int age) : this("No name", age)
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }

            set { name = value; }
        }

        public int Age
        {
            get { return age; }

            set { age = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}