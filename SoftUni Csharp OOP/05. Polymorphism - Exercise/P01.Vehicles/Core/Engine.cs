namespace Vehicles.Core
{
    using System;

    using Interfaces;
    using Exceptions;

    using IO.Interfaces;
    using Factories.Interfaces;

    using Models;
    using Factories;

    public class Engine : IEngine
    {
        private readonly IReader _reader;

        private readonly IWriter _writer;

        private readonly IVehicleFactory _vehicleFactory;

        private Engine()
        {
            this._vehicleFactory = new VehicleFactory();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this._reader = reader;
            this._writer = writer;
        }

        public void RunApplication()
        {
            try
            {
                string[] carInfo = this._reader.ReadLine().Split();

                string[] truckInfo = this._reader.ReadLine().Split();

                Vehicle car =
                    this._vehicleFactory.CreateVehicle(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));

                Vehicle truck = this._vehicleFactory.CreateVehicle(truckInfo[0], double.Parse(truckInfo[1]),
                    double.Parse(truckInfo[2]));

                ExecuteCommands(car, truck);

                this._writer.WriteLine(car.ToString());
                this._writer.WriteLine(truck.ToString());
            }
            catch (InvalidVehicleException ive)
            {
                this._writer.WriteLine(ive.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                this._writer.WriteLine("Invalid input!");
            }
            catch (ArgumentException ae)
            {
                this._writer.WriteLine(ae.Message);
            }
        }

        private void ExecuteCommands(Vehicle car, Vehicle truck)
        {
            int countOfCommands = int.Parse(this._reader.ReadLine());

            for (int index = 0; index < countOfCommands; index++)
            {
                string[] commandArgs = this._reader.ReadLine().Split();

                string commandType = commandArgs[0];
                string vehicleType = commandArgs[1];

                double litersOrDistance = double.Parse(commandArgs[2]);

                if (commandType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        this._writer.WriteLine(car.Drive(litersOrDistance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        this._writer.WriteLine(truck.Drive(litersOrDistance));
                    }
                }

                else if (commandType == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(litersOrDistance);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(litersOrDistance);
                    }
                }
            }
        }
    }
}
