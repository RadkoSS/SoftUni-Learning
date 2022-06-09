using System;
using System.Linq;
using System.Collections.Generic;

namespace RawData
{
    public class StartUp
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine().Split();
                InitializeCar(carInfo, cars);
            }

            string type = Console.ReadLine();

            PrintAllFromType(type, cars);
        }

        static void InitializeCar(string[] carInfo, List<Car> cars)
        {
            var model = carInfo[0];

            var engineSpeed = int.Parse(carInfo[1]);

            var enginePower = int.Parse(carInfo[2]);

            var cargoWeight = int.Parse(carInfo[3]);

            var cargoType = carInfo[4];

            var tyre1Pressure = double.Parse(carInfo[5]);

            var tyre1Age = int.Parse(carInfo[6]);

            var tyre2Pressure = double.Parse(carInfo[7]);

            var tyre2Age = int.Parse(carInfo[8]);

            var tyre3Pressure = double.Parse(carInfo[9]);

            var tyre3Age = int.Parse(carInfo[10]);

            var tyre4Pressure = double.Parse(carInfo[11]);

            var tyre4Age = int.Parse(carInfo[12]);

            List<Tires> tires = new List<Tires>();

            var engine = new Engine(engineSpeed, enginePower);

            var cargo = new Cargo(cargoType, cargoWeight);

            tires.Add(new Tires(tyre1Age, tyre1Pressure));

            tires.Add(new Tires(tyre2Age, tyre2Pressure));

            tires.Add(new Tires(tyre3Age, tyre3Pressure));

            tires.Add(new Tires(tyre4Age, tyre4Pressure));

            var carToAdd = new Car(model, engine, cargo, tires);

            cars.Add(carToAdd);
        }

        static void PrintAllFromType(string type, List<Car> cars) 
        {
            var wantedCars = new List<Car>();

            if (type == "fragile")
            {
                wantedCars = cars.Where(car => car.Cargo.Type == type).Where(car => car.Tires.Any(tyre => tyre.Pressure < 1)).ToList(); 
            }

            else if (type == "flammable")
            {
                wantedCars = cars.Where(car => car.Cargo.Type == type).Where(car => car.Engine.Power > 250).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, wantedCars));
        }
    }
}
