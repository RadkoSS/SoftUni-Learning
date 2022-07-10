namespace PersonInfo
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            IPerson person = new Citizen("Radko", 18);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
