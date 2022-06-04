using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personalInfo = Console.ReadLine().Split();

                people.Add(new Person(personalInfo[0], int.Parse(personalInfo[1])));
            }

            List<Person> overThirty = people.FindAll(person => person.Age > 30);

            Console.WriteLine(string.Join(Environment.NewLine, overThirty.OrderBy(person => person.Name)));
        }
    }
}
