﻿namespace ValidationAttributes.Models
{
    using System;

    using Utilities;
    using Utilities.Attributes;

    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        private string _name;

        private int _age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequired]
        public string Name { get; private set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; private set; }
    }
}
