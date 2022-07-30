namespace RepairShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography;
    using NUnit.Framework;
    using NUnit.Framework.Internal.Execution;

    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage _garage;

            [SetUp]
            public void SetUp()
            {
                this._garage = new Garage("RadkoSGarage", 7);

                this._garage.AddCar(new Car("Audi A3 1.8T", 1));

                this._garage.AddCar(new Car("Audi RS6 Avant", 2));

                this._garage.AddCar(new Car("Audi R8", 2));

                this._garage.AddCar(new Car("FixedCar 1", 0));
                this._garage.AddCar(new Car("FixedCar 2", 0));
                this._garage.AddCar(new Car("FixedCar 3", 0));
            }

            [TestCase("SpasGarage", 5)]
            [TestCase("JustGarage", 20)]
            public void TestCtor_ShouldMakeCorrectInitialization(params object[] info)
            {
                Garage garage = new Garage((string)info[0], (int)info[1]);

                string expectedName = (string)info[0];
                int expectedCount = (int)info[1];
                int expectedCarsInList = 0;

                string actualName = garage.Name;
                int actualCount = garage.MechanicsAvailable;
                int actualCarsInList = garage.CarsInGarage;

                Assert.AreEqual(expectedName, actualName, "Name should be initialized correctly!");

                Assert.AreEqual(expectedCount, actualCount, "Mechanics count should be initialized correctly!");

                Assert.AreEqual(expectedCarsInList, actualCarsInList, "Cars should be initialized correctly!");
            }


            [TestCase(null, 2)]
            [TestCase("", 5)]
            public void TestNameProperty_ShouldThrowExceptionWhenNameIsEmpty(params object[] info)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage((string)info[0], (int)info[1]);
                }, "Name must not be null or empty!");
            }

            [TestCase("JustGarage", 0)]
            [TestCase("JGarage", -1)]
            [TestCase("Just", -10)]
            public void TestMechanicsCount_ShouldThrowExceptionWhenCountIsZeroOrNegative(params object[] info)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage((string)info[0], (int)info[1]);
                }, "Mechanics count must less than or equal to zero!");
            }


            [TestCase("RadkoSGarage", 5)]
            public void TestCarsCount_ShouldReturnCorrectCount(params object[] info)
            {
                Garage garage = new Garage((string)info[0], (int)info[1]);

                garage.AddCar(new Car("Audi A3", 1));
                garage.AddCar(new Car("Audi S3", 1));
                garage.AddCar(new Car("BMW M3", 2));
                garage.AddCar(new Car("Mercedes C320 CDI", 1));

                int expectedCount = 4;

                int actualCount = garage.CarsInGarage;

                Assert.AreEqual(expectedCount, actualCount, "Cars count should return correct number!");
            }


            [TestCase("Audi RS3", 2)]
            [TestCase("BMW M5", 1)]
            [TestCase("BMW E61", 7)]
            public void TestAddCar_ShouldAddCarToTheCollection(params object[] info)
            {
                int count = this._garage.CarsInGarage;

                this._garage.AddCar(new Car((string)info[0], (int)info[1]));

                int expectedCountOfCars = count + 1;
                int actualCountOfCars = this._garage.CarsInGarage;

                Assert.AreEqual(expectedCountOfCars, actualCountOfCars, "AddCar method should add car to the collection!");
            }

            [TestCase("Audi RS3", 2, "BMW E61", 5)]
            public void TestAddCar_ShouldThrowExceptionWhenThereAreNoFreeMechanics(params object[] info)
            {
                this._garage.AddCar(new Car((string)info[0], (int)info[1]));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this._garage.AddCar(new Car((string) info[2], (int) info[3]));
                }, "AddCar method should throw exception when there are no free mechanics");
            }


            [TestCase("Audi A3 1.8T")]
            [TestCase("Audi RS6 Avant")]
            [TestCase("Audi R8")]
            public void TestFixCarMethod_ShouldFixCarAndSetIssuesCountToZero(string carName)
            {
                int expectedIssuesCountAfterRepair = 0;

                int actualIssuesCountAfterRepair = this._garage.FixCar(carName).NumberOfIssues;

                Assert.AreEqual(expectedIssuesCountAfterRepair, actualIssuesCountAfterRepair, "Car issues must be set to zero when car is successfully repaired!");
            }

            [TestCase("k")]
            [TestCase("u")]
            public void TestFixCarMethod_ShouldThrowExceptionWhenCarWithProvidedNameCanNotBeFound(string carName)
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this._garage.FixCar(carName);
                }, "Fix car must throw exception when car with the given name can not be found!");
            }

            [Test]
            public void TestRemoveFixedCarMethod_ShouldRemoveAllCarsWithZeroIssuesCount()
            {
                int expectedRemoveCount = 3;

                int actualRemoveCount = this._garage.RemoveFixedCar();

                Assert.AreEqual(expectedRemoveCount, actualRemoveCount, "RemoveFixedCar method should return correct count of removed repaired cars!");
            }

            [Test]
            public void TestRemoveFixedCarMethod_ShouldThrowExceptionWhenThereAreNoRepairedCars()
            {
                this._garage.RemoveFixedCar();

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this._garage.RemoveFixedCar();
                }, "RemoveFixedCar method should throw exception when there are no repaired cars!");
            }

            [TestCase("Audi RS2", 0, "Audi A3 1.8T", 0, "BMW E61", 5, "Audi A4", 2)]
            public void TestReport_ShouldReturnCorrectInformationAboutCarsThatNeedRepair(params object[] info)
            {
                Garage garage = new Garage("RadkoSGarage", 10);

                List<Car> expectedUnfixedCarsList = new List<Car>();

                for (int i = 0; i < info.Length - 1; i += 2)
                {
                    Car car = new Car((string) info[i], (int) info[i + 1]);

                    garage.AddCar(car);

                    if (!car.IsFixed)
                    {
                        expectedUnfixedCarsList.Add(car);
                    }
                }

                string expectedCarNames = string.Join(", ", expectedUnfixedCarsList.Select(car => car.CarModel));

                string expectedReport = $"There are {expectedUnfixedCarsList.Count} which are not fixed: {expectedCarNames}.";

                string actualReport = garage.Report();

                Assert.AreEqual(expectedReport, actualReport, "Report must show correct information!");
            }
        }
    }
}