using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            EnterCars(cars, numberOfCars);

            ExecuteCommands(cars);

            PrintAllCars(cars);
        }

        static void EnterCars(List<Car> cars, int numberOfCars)
        {
            for (int car = 1; car <= numberOfCars; car++)
            {
                var inputLine = Console.ReadLine().Split();

                var model = inputLine[0];

                var fuelAmount = double.Parse(inputLine[1]);

                var fuelConsumption = double.Parse(inputLine[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));

            }
        }

        static void ExecuteCommands(List<Car> cars)
        {
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();

                var carModel = tokens[1];

                var driveDistance = double.Parse(tokens[2]);

                var car = cars.Find(car => car.Model == carModel);

                if (car.IsFuelEnough(driveDistance))
                {
                    car.FuelAmount -= driveDistance * car.FuelConsumption;

                    car.DistanceTravelled += driveDistance;
                }

                else
                    Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        static void PrintAllCars(List<Car> cars) => Console.WriteLine(string.Join(Environment.NewLine, cars));
    }
}
