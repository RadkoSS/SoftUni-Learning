using System;

namespace P07.Tuple
{
    public class StartUp
    {
        static void Main()
        {
            var nameAndAdress = Console.ReadLine().Split();

            var fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";

            var address = nameAndAdress.Length <= 3 ? nameAndAdress[2] : $"{nameAndAdress[2]} {nameAndAdress[3]}";

            var firstTuple = new Tuple<string, string>(fullName, address);

            var nameAndLiters = Console.ReadLine().Split();

            var name = nameAndLiters[0];

            var liters = int.Parse(nameAndLiters[1]);

            var secondTuple = new Tuple<string, int>(name, liters);

            var integerAndDouble = Console.ReadLine().Split();

            var integer = int.Parse(integerAndDouble[0]);

            var floatingNumber = double.Parse(integerAndDouble[1]);

            var thirdTuple = new Tuple<int, double>(integer, floatingNumber);

            Console.WriteLine(firstTuple);

            Console.WriteLine(secondTuple);

            Console.WriteLine(thirdTuple);
        }
    }
}
