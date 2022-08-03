namespace Gyms.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using NUnit.Framework;

    public class GymsTests
    {
        // Implement unit tests here

        [Test]
        public void TestConstructorInitCollection()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            FieldInfo[] privateFields = gym.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo athletesList = privateFields.FirstOrDefault(f => f.Name == "athletes");

            List<Athlete> expectedList = new List<Athlete>();

            List<Athlete> actualList = athletesList.GetValue(gym) as List<Athlete>;

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void TestConstructorInitSizeField()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            FieldInfo[] privateFields = gym.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo gymSizeField = privateFields.FirstOrDefault(f => f.Name == "size");

            int expectedSize = 10;

            int actualSize = (int)gymSizeField.GetValue(gym);

            Assert.AreEqual(expectedSize, actualSize);
        }

        [Test]
        public void TestSizeGetter()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            int expectedSizeGetter = 10;

            int actualSizeGetter = gym.Capacity;

            Assert.AreEqual(expectedSizeGetter, actualSizeGetter);
        }

        [Test]
        public void TestConstructorInitNameProperty()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            FieldInfo[] privateFields = gym.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo gymNameField = privateFields.FirstOrDefault(f => f.Name == "name");

            string expectedName = "HardCore Gym";

            string actualName = (string)gymNameField.GetValue(gym);

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void TestNameGetter()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            string expectedNameGetter = "HardCore Gym";

            string actualNameGetter = gym.Name;

            Assert.AreEqual(expectedNameGetter, actualNameGetter);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameSetterShouldThrowExceptionWhenInvalidNameIsGiven(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 5);
            }, "Invalid gym name.");
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void NameSetterShouldThrowExceptionWhenInvalidNameIsGiven(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("HardCore", capacity);
            }, "Invalid gym size.");
        }

        [Test]
        public void CountGetterShouldReturnCorrectValueWhenGymHasNoAthletes()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            int expectedCount = 0;

            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountGetterShouldReturnCorrectValue()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            gym.AddAthlete(new Athlete("Radoslav Gervaziev"));

            int expectedCount = 1;

            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddAthleteShouldAddToTheCollection()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete radko = new Athlete("Radoslav Gervaziev");

            Athlete sasho = new Athlete("Alex Gospodinov");

            Athlete chichoDani = new Athlete("Daniel Asenov");

            gym.AddAthlete(radko);
            gym.AddAthlete(sasho);
            gym.AddAthlete(chichoDani);

            FieldInfo[] privateFields = gym.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo athletesList = privateFields.FirstOrDefault(f => f.Name == "athletes");

            List<Athlete> expectedList = new List<Athlete>()
            {
                radko, sasho, chichoDani
            };

            List<Athlete> actualList = athletesList.GetValue(gym) as List<Athlete>;

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCase(2)]
        public void AddAthleteShouldThrowExceptionWhenAddingMoreAthletesThanTheGymsSize(int size)
        {
            Gym gym = new Gym("HardCore", size);

            Athlete radko = new Athlete("Radoslav Gervaziev");

            Athlete sasho = new Athlete("Alex Gospodinov");

            Athlete chichoDani = new Athlete("Daniel Asenov");

            gym.AddAthlete(radko);
            gym.AddAthlete(sasho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(chichoDani);
            }, "The gym is full.");
        }

        [Test]
        public void RemoveAthleteShouldRemoveFromCollection()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete radko = new Athlete("Radoslav Gervaziev");

            Athlete sasho = new Athlete("Alex Gospodinov");

            Athlete chichoDani = new Athlete("Daniel Asenov");

            gym.AddAthlete(radko);
            gym.AddAthlete(sasho);
            gym.AddAthlete(chichoDani);

            gym.RemoveAthlete("Alex Gospodinov");

            FieldInfo[] privateFields = gym.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();

            FieldInfo athletesListField = privateFields.FirstOrDefault(f => f.Name == "athletes");

            List<Athlete> expectedList = new List<Athlete>()
            {
                radko, chichoDani
            };

            List<Athlete> actualList = athletesListField.GetValue(gym) as List<Athlete>;

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void RemoveAthleteShouldThrowExceptionWhenDeletingNonExistingAthlete()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete sasho = new Athlete("Alex Gospodinov");

            Athlete chichoDani = new Athlete("Daniel Asenov");

            gym.AddAthlete(sasho);
            gym.AddAthlete(chichoDani);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Radoslav Gervaziev");

            }, "The athlete doesn't exist.");
        }

        [Test]
        public void InjureAthleteShouldSetInjuredToTrue()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete ivan = new Athlete("Ivan Yordanov");

            gym.AddAthlete(ivan);

            gym.InjureAthlete("Ivan Yordanov");

            Assert.IsTrue(ivan.IsInjured);
        }

        [Test]
        public void InjureAthleteShouldReturnTheAthlete()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete ivan = new Athlete("Ivan Yordanov");

            gym.AddAthlete(ivan);

            Athlete expectedAthlete = ivan;

            Athlete actualAthlete = gym.InjureAthlete("Ivan Yordanov");

            Assert.AreEqual(expectedAthlete, actualAthlete);
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionWhenThereIsNoSuchAthlete()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete ivan = new Athlete("Ivan Yordanov");

            gym.AddAthlete(ivan);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Ivan");

            }, "The athlete doesn't exist.");
        }

        [Test]
        public void ReportShouldReturnCorrectText()
        {
            Gym gym = new Gym("HardCore Gym", 10);

            Athlete sasho = new Athlete("Alex Gospodinov");

            Athlete chichoDani = new Athlete("Daniel Asenov");

            gym.AddAthlete(sasho);
            gym.AddAthlete(chichoDani);

            List<Athlete> list = new List<Athlete>()
            {
                sasho, chichoDani
            };

            string expectedAthleteNames = string.Join(", ", list.Where(x => !x.IsInjured).Select(f => f.FullName));

            string expectedReport = $"Active athletes at {gym.Name}: {expectedAthleteNames}";

            string actualReport = gym.Report();

            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
