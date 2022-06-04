using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person Peter = new Person();
            Peter.Name = "Peter";
            Peter.Age = 20;

            Person George = new Person("George", 18);

            Person Jose = new Person("Jose", 43);

        }
    }
}
