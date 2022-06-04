using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Family family = new Family();

            InitializeFamily(family);

            Console.WriteLine(family.GetOldestMember());
        }

        static void InitializeFamily(Family family)
        {

            int countOfmembers = int.Parse(Console.ReadLine());

            for (int member = 1; member <= countOfmembers; member++)
            {
                string[] memberInfo = Console.ReadLine().Split();

                Person person = new Person(memberInfo[0], int.Parse(memberInfo[1]));

                family.AddMember(person);
            }

        }
    }
}
