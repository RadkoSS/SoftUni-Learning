using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person person = new Person();

            Person secondPerson = new Person(18);

            Person thirdPerson = new Person("Radko", 18);

        }
    }
}
