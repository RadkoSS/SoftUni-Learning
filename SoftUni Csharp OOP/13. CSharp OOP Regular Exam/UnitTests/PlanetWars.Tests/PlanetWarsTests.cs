namespace PlanetWars.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Reflection;
    using System.Collections.Generic;

    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Planet", 100);

            }

            [Test]
            public void WeaponTestConstructor()
            {
                Weapon w = new Weapon("XL", 4, 7);

                Assert.AreEqual(w.Name, "XL");

                Assert.AreEqual(w.Price, 4);

                Assert.AreEqual(w.DestructionLevel, 7);
            }

            [TestCase(-0.000001)]
            [TestCase(-5)]
            [TestCase(double.MinValue)]
            public void WeaponPriceSetterShouldThrowException(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon w = new Weapon("XL", price, 7);
                });
            }

            [Test]
            public void WeaponIncreaseDestructionLevel()
            {
                Weapon w = new Weapon("XL", 4, 7);

                w.IncreaseDestructionLevel();

                Assert.AreEqual(w.DestructionLevel, 8);
            }

            [Test]
            public void WeaponTestIsNuclearShouldReturnFalse()
            {
                Weapon w = new Weapon("XL", 4, 7);

                Assert.IsFalse(w.IsNuclear);
            }

            [Test]
            public void WeaponTestIsNuclearShouldReturnTrue()
            {
                Weapon w = new Weapon("XL", 4, 10);

                Assert.IsTrue(w.IsNuclear);
            }

            [Test]
            public void PlanetTestConstructor()
            {
                Assert.AreEqual(planet.Name, "Planet");

                Assert.AreEqual(planet.Budget, 100);
            }

            [Test]
            public void TestConstructorInitializationOfCollections()
            {
                FieldInfo[] fields = this.planet.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

                FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "weapons");

                List<Weapon> expectedList = new List<Weapon>();

                List<Weapon> actualList = collectionField.GetValue(this.planet) as List<Weapon>;

                CollectionAssert.AreEqual(expectedList, actualList);
            }

            [TestCase(null)]
            [TestCase("")]
            public void NameSetterShouldThrowException(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet p = new Planet(name, 12);
                });
            }

            [TestCase(-0.0001)]
            [TestCase(-1000)]
            [TestCase(double.MinValue)]
            public void BudgetSetterShouldThrowException(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet p = new Planet("NormalName", budget);
                });
            }

            [Test]
            public void TestReadOnlyCollectionGetter()
            {
                var collection = planet.Weapons;

                Assert.That(collection is IReadOnlyCollection<Weapon>);
            }

            [Test]
            public void TestMilitaryPowerRatioWhenThereAreNoWeapons()
            {
                double expected = 0;
                double actual = planet.MilitaryPowerRatio;

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void TestMilitaryPowerRatioWhenThereWeapons()
            {
                Weapon first = new Weapon("Weapon1", 5, 5);
                Weapon second = new Weapon("Weapon2", 5, 3);

                planet.AddWeapon(first);
                planet.AddWeapon(second);

                double expected = 8;
                double actual = planet.MilitaryPowerRatio;

                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void TestProfit()
            {
                double expected = planet.Budget + 5;

                planet.Profit(5);

                double actual = planet.Budget;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void TestSpend()
            {
                double expected = planet.Budget - 5;

                planet.SpendFunds(5);

                double actual = planet.Budget;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void TestSpendShouldThrowException()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(100.00001);
                });
            }

            [Test]
            public void TestAddWeapon()
            {
                Weapon first = new Weapon("Weapon1", 5, 5);
                Weapon second = new Weapon("Weapon2", 5, 3);

                planet.AddWeapon(first);
                planet.AddWeapon(second);

                var expectedCollection = new List<Weapon> { first, second };

                var actualCollection = planet.Weapons;

                CollectionAssert.AreEqual(expectedCollection, actualCollection);
            }

            [Test]
            public void TestAddWeaponShouldThrowException()
            {
                Weapon first = new Weapon("Weapon1", 5, 5);
                Weapon second = new Weapon("Weapon2", 5, 3);

                planet.AddWeapon(first);
                planet.AddWeapon(second);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(second);
                });
            }

            [Test]
            public void TestRemoveWeapon()
            {
                Weapon first = new Weapon("Weapon1", 5, 5);
                Weapon second = new Weapon("Weapon2", 5, 3);
                Weapon third = new Weapon("Weapon3", 4, 8);

                planet.AddWeapon(first);
                planet.AddWeapon(second);
                planet.AddWeapon(third);

                planet.RemoveWeapon("Weapon2");

                var expectedCollection = new List<Weapon> { first, third };

                var actualCollection = planet.Weapons;

                CollectionAssert.AreEqual(expectedCollection, actualCollection);
            }

            [Test]
            public void TestUpgradeWeapon()
            {
                Weapon weapon = new Weapon("Weapon3", 4, 8);

                planet.AddWeapon(weapon);

                planet.UpgradeWeapon("Weapon3");

                int expectedDestructionLevel = 9;
                int actualDestructionLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedDestructionLevel, actualDestructionLevel);
            }

            [Test]
            public void TestUpgradeWeaponShouldThrowException()
            {
                Weapon weapon = new Weapon("Weapon3", 4, 8);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("NonExistingOne");
                });
            }

            [Test]
            public void TestDestructOpponent()
            {
                Weapon weapon = new Weapon("Weapon3", 4, 8);
                planet.AddWeapon(weapon);

                Planet opponentPlanet = new Planet("Mars", 5);
                Weapon weapon2 = new Weapon("Weapon", 4, 7);
                opponentPlanet.AddWeapon(weapon2);

                string expected = "Mars is destructed!";
                string actual = planet.DestructOpponent(opponentPlanet);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void TestDestructOpponentShouldThrowException()
            {
                Weapon weapon = new Weapon("Weapon3", 4, 8);
                planet.AddWeapon(weapon);

                Planet opponentPlanet = new Planet("Mars", 5);
                Weapon weapon2 = new Weapon("Weapon", 4, 55);
                opponentPlanet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponentPlanet);
                });
            }
        }
    }
}
