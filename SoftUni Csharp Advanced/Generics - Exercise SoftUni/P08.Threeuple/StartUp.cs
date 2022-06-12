using System;

namespace P08.Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            var nameAndAdress = Console.ReadLine().Split();

            var fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";

            var address = nameAndAdress[2];

            var town = nameAndAdress.Length > 4 ? $"{nameAndAdress[3]} {nameAndAdress[4]}" : nameAndAdress[3];

            var firstTuple = new Threeuple<string, string, string>(fullName, address, town);

            var nameLitersStatus = Console.ReadLine().Split();

            var name = nameLitersStatus[0];

            var liters = int.Parse(nameLitersStatus[1]);

            var isDrunk = nameLitersStatus[2] == "drunk" ? true : false;

            var secondTuple = new Threeuple<string, int, bool>(name, liters, isDrunk);

            var nameNumberAndBankName = Console.ReadLine().Split();

            var secondName = nameNumberAndBankName[0];

            var floatingNumber = double.Parse(nameNumberAndBankName[1]);

            var bankName = nameNumberAndBankName[2];

            var thirdTuple = new Threeuple<string, double, string>(secondName, floatingNumber, bankName);

            Console.WriteLine(firstTuple);

            Console.WriteLine(secondTuple);

            Console.WriteLine(thirdTuple);
        }
    }
}
