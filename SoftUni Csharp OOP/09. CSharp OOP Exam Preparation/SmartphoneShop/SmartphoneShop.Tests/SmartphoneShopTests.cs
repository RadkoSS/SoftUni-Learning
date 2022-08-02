namespace SmartphoneShop.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(10)]
        public void ConstructorShouldInitializeCorrectly(int capacity)
        {
            Shop shop = new Shop(capacity);

            int expectedCapacity = capacity;

            int actualCapacity = shop.Capacity;

            Type type = shop.GetType();

            FieldInfo[] privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo phonesListField = privateFields.FirstOrDefault(f => f.Name == "phones");

            List<Smartphone> expectedList = new List<Smartphone>();

            List<Smartphone> actualList = phonesListField.GetValue(shop) as List<Smartphone>;

            Assert.AreEqual(expectedCapacity, actualCapacity);

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void CapacityFieldShouldExistAndKeepCorrectValue()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);
            Smartphone second = new Smartphone("IPhone", 110);
            Smartphone third = new Smartphone("Xiomi", 102);

            shop.Add(first);
            shop.Add(second);
            shop.Add(third);

            FieldInfo[] privateFields = shop.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo capacityField = privateFields.FirstOrDefault(f => f.Name == "capacity");

            int expectedCapacity = 5;

            int actualCapacity = (int)capacityField.GetValue(shop);

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-1000000)]
        public void CapacityShouldThrowExceptionIfValueIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            });
        }

        [TestCase(10)]
        public void CountShouldReturnCorrectNumber(int capacity)
        {
            Shop shop = new Shop(capacity);

            Smartphone first = new Smartphone("Samsung", 100);
            Smartphone second = new Smartphone("IPhone", 110);
            Smartphone third = new Smartphone("Xiomi", 102);

            shop.Add(first);
            shop.Add(second);
            shop.Add(third);

            int expectedCount = 3;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnZeroWhenThereIsNoPhoneInCollection()
        {
            Shop shop = new Shop(5);

            int expectedCount = 0;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldAddItemToCollection()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);
            Smartphone second = new Smartphone("IPhone", 110);
            Smartphone third = new Smartphone("Xiomi", 102);

            shop.Add(first);
            shop.Add(second);
            shop.Add(third);

            FieldInfo[] privateFields = shop.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            List<Smartphone> expectedPhoneList = new List<Smartphone>()
            {
                first, second, third
            };

            List<Smartphone> actualPhoneList = privateFields.FirstOrDefault(f => f.Name == "phones").GetValue(shop) as List<Smartphone>;

            CollectionAssert.AreEqual(expectedPhoneList, actualPhoneList);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingExistingPhone()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Shop shop = new Shop(5);

                Smartphone first = new Smartphone("Samsung", 100);

                shop.Add(first);
                shop.Add(first);
            }, "The phone model already exists.");
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingMorePhonesThanShopsCapacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Shop shop = new Shop(1);

                Smartphone first = new Smartphone("Samsung", 100);
                Smartphone second = new Smartphone("IPhone", 110);

                shop.Add(first);
                shop.Add(second);
            }, "The shop is full.");
        }

        [Test]
        public void RemoveShouldRemovePhoneFromCollection()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);
            Smartphone second = new Smartphone("IPhone", 110);
            Smartphone third = new Smartphone("Xiomi", 102);

            shop.Add(first);
            shop.Add(second);
            shop.Add(third);

            shop.Remove("Samsung");

            FieldInfo[] privateFields = shop.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo phonesListField = privateFields.FirstOrDefault(f => f.Name == "phones");

            List<Smartphone> expectedList = new List<Smartphone>()
            {
                second, third
            };

            List<Smartphone> actualList = phonesListField.GetValue(shop) as List<Smartphone>;


            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenBeingGivenAnonExistingModelName()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);
            Smartphone second = new Smartphone("IPhone", 110);
            Smartphone third = new Smartphone("Xiomi", 102);

            shop.Add(first);
            shop.Add(second);
            shop.Add(third);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("MDO");
            }, "The phone model doesn't exist.");
        }

        [Test]
        public void TestPhoneShouldLowerBatteryPercentageWhenPhoneIsBeingUsed()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);
            
            first.CurrentBateryCharge = 100;

            shop.Add(first);

            shop.TestPhone("Samsung", 20);

            int expectedPerc = 80;

            int actualPerc = first.CurrentBateryCharge;

            Assert.AreEqual(expectedPerc, actualPerc);
        }

        [Test]
        public void TestPhoneShouldThrowException()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);

            first.CurrentBateryCharge = 100;

            shop.Add(first);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("MDO", 20);
            }, "Model does not exist!");
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWhenPhoneDoesNotHaveEnoughBattery()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);

            first.CurrentBateryCharge = 10;

            shop.Add(first);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Samsung", 20);
            }, "Phone does not have enough battery!");
        }

        [Test]
        public void ChargePhoneShouldChargeCorrectPhoneModel()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);

            first.CurrentBateryCharge = 50;

            shop.Add(first);

            shop.ChargePhone("Samsung");

            int expected = first.MaximumBatteryCharge;
            int actual = first.CurrentBateryCharge;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChargePhoneShouldThrowExceptionWhenTryingToChargeNonExistingPhoneModel()
        {
            Shop shop = new Shop(5);

            Smartphone first = new Smartphone("Samsung", 100);

            first.CurrentBateryCharge = 50;

            shop.Add(first);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("MDO");
            }, "Model doesn't exist!");
        }
    }
}