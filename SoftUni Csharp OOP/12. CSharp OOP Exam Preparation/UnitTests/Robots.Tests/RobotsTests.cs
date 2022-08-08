namespace Robots.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Reflection;
    using System.Collections.Generic;

    public class RobotsTests
    {
        public RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            this.manager = new RobotManager(3);
        }

        [Test]
        public void TestConstructorInitializationOfCapacity()
        {
            FieldInfo[] fields = this.manager.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

            FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "capacity");

            int expectedCapacity = 3;

            int actualCapacity = (int)collectionField.GetValue(this.manager);

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void TestConstructorInitializationOfCollections()
        {
            FieldInfo[] fields = this.manager.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

            FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "robots");

            List<Robot> expectedList = new List<Robot>();

            List<Robot> actualList = collectionField.GetValue(this.manager) as List<Robot>;

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void TestCapacityGetter()
        {
            int expectedCapacity = 3;
            int actualCapacity = this.manager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(-1)]
        [TestCase(-123)]
        [TestCase(-10000)]
        public void CapacitySetterShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager rm = new RobotManager(capacity);
            });
        }

        [Test]
        public void TestCountGetterWhenCollectionIsEmpty()
        {
            int expected = 0;
            int actual = this.manager.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestCountGetter()
        {
            Robot robot1 = new Robot("Radko", 100);
            Robot robot2 = new Robot("Dani", 112);
            Robot robot3 = new Robot("Alex", 101);

            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Add(robot3);

            int expected = 3;
            int actual = this.manager.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAdd()
        {
            Robot robot1 = new Robot("Radko", 100);
            Robot robot2 = new Robot("Dani", 112);
            Robot robot3 = new Robot("Alex", 101);

            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Add(robot3);

            FieldInfo[] fields = this.manager.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

            FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "robots");

            List<Robot> expectedList = new List<Robot>()
            {
                robot1, robot2, robot3
            };

            List<Robot> actualList = collectionField.GetValue(this.manager) as List<Robot>;

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenRobotWithSuchNameDoesNotExist()
        {
            Robot robot1 = new Robot("Radko", 100);
            Robot robot2 = new Robot("Dani", 112);
            Robot robot3 = new Robot("Radko", 101);

            this.manager.Add(robot1);
            this.manager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.manager.Add(robot3);
            });
        }

        [Test]
        public void TestAddShouldThrowExceptionWhenThereIsNoFreeSpace()
        {
            Robot robot1 = new Robot("Radko", 100);
            Robot robot2 = new Robot("Dani", 112);
            Robot robot3 = new Robot("Ivelin", 101);
            Robot robot4 = new Robot("Yordan", 101);
            
            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Add(robot3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.manager.Add(robot4);
            });
        }

        [Test]
        public void TestRemove()
        {
            Robot robot1 = new Robot("Radko", 100);
            Robot robot2 = new Robot("Dani", 112);
            Robot robot3 = new Robot("Ivelin", 101);

            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Add(robot3);

            this.manager.Remove("Radko");

            this.manager.Remove("Ivelin");

            FieldInfo[] fields = this.manager.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

            FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "robots");

            List<Robot> expected = new List<Robot>()
            {
                robot2
            };

            List<Robot> actual = collectionField.GetValue(this.manager) as List<Robot>;

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRemoveShouldThrowException()
        {
            Robot robot1 = new Robot("Radko", 100);
            Robot robot2 = new Robot("Dani", 112);
            Robot robot3 = new Robot("Ivelin", 101);

            this.manager.Add(robot1);
            this.manager.Add(robot2);
            this.manager.Add(robot3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.manager.Remove("Kiro");
            });
        }

        [Test]
        public void TestWork()
        {
            Robot robot1 = new Robot("Radko", 100);

            this.manager.Add(robot1);

            this.manager.Work("Radko", "Ebane", 55);

            int expectedBatteryLeft = 45;
            int actualBatteryLeft = robot1.Battery;

            Assert.AreEqual(expectedBatteryLeft, actualBatteryLeft);
        }

        [Test]
        public void TestWorkThrowExceptionWhenThereIsNoSuchRobot()
        {
            Robot robot1 = new Robot("Radko", 100);

            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.manager.Work("Sasho", "Cleaning", 55);
            });
        }

        [Test]
        public void TestWorkThrowExceptionWhenThereIsNotEnoughBattery()
        {
            Robot robot1 = new Robot("Radko", 100);

            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.manager.Work("Radko", "Qko ebane", 101);
            });
        }

        [Test]
        public void TestCharge()
        {
            Robot robot1 = new Robot("Radko", 100);

            this.manager.Add(robot1);

            this.manager.Work("Radko", "Ebane", 99);

            this.manager.Charge("Radko");

            int expectedBattery = 100;
            int actualBattery = robot1.Battery;

            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void TestChargeThrowExceptionWhenThereIsNoSuchRobot()
        {
            Robot robot1 = new Robot("Radko", 100);

            this.manager.Add(robot1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.manager.Charge("Valeri Bojinov");
            });
        }
    }
}
