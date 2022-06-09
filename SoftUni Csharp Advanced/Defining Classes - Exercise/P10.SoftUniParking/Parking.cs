using System.Linq;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        private List<Car> cars;

        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }

        private int Capacity 
        { 
            get { return capacity; } 
            set { capacity = value; } 
        }

        public List<Car> Cars { get; set; }

        public string AddCar(Car car)
        {
            if (IsRegNumberExisting(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (IsParkingFull)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var carToRemove = GetCar(registrationNumber);

            if (carToRemove != null)
            {
                this.Cars.Remove(carToRemove);

                return $"Successfully removed {registrationNumber}";
            }

            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }


        public Car GetCar(string registrationNumber) => this.Cars.FirstOrDefault(car => car.RegistrationNumber == registrationNumber);


        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNumber in registrationNumbers)
            {
                var searchedCar = GetCar(regNumber);

                if (searchedCar != null)
                {
                    this.Cars.Remove(searchedCar);
                }
            }
        }

        public int Count => this.Cars.Count;


        public bool IsRegNumberExisting(string regNumber) => this.Cars.Any(car => car.RegistrationNumber == regNumber);


        public bool IsParkingFull => this.Cars.Count >= this.Capacity;

    }
}
