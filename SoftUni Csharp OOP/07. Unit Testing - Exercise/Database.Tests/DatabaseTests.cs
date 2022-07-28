namespace Database.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
             this.db = new Database();
        }

        [Test]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestConstructor_ShouldInitializeArrayCorrectly(int[] numbers)
        {
             this.db = new Database(numbers);

            int[] expectedNumbers = numbers;
            int[] actualNumbers = this.db.Fetch();

            CollectionAssert.AreEqual(expectedNumbers, actualNumbers, "Constructor should initialize numbers to the array correctly!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void TestConstructor_ShouldThrowExceptionWhenAddingMoreNumbersThan16(int[] numbers)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db = new Database(numbers);
            }, "There must be an exception thrown when trying to add more than 16 numbers!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestCount_ShouldReturnTheCorrectElementsCount(int[] numbers)
        {
            this.db = new Database(numbers);

            int expectedCount = numbers.Length;
            int actualCount = this.db.Count;

            Assert.AreEqual(expectedCount, actualCount, "Count property getter should return the correct count of elements!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void TestAdd_ShouldAddElementToNextFreeCell(int[] numbers)
        {
            this.db = new Database(numbers);
            this.db.Add(1);

            List<int> numbersList = new List<int>(numbers) { 1 };

            int[] expectedNumbers = numbersList.ToArray();
            int[] actualNumbers = this.db.Fetch();

            CollectionAssert.AreEqual(expectedNumbers, actualNumbers, "Add method should add element to the next free cell!");
        }

        
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void TestAdd_ShouldThrowAnExceptionWhenTryingToAddMoreThanTheAllowedNumbers(int[] numbers)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db = new Database(numbers);
                this.db.Add(1);

            }, "Add should throw an exception when trying to add more than 16 numbers!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestRemove_ShouldRemoveAnItemFromTheLastPosition(int[] numbers)
        {
            this.db = new Database(numbers);

            this.db.Remove();

            List<int> numbersList = new List<int>(numbers.Take(numbers.Length - 1));

            int[] expectedNumbers = numbersList.ToArray();
            int[] actualNumbers = this.db.Fetch();

            CollectionAssert.AreEqual(expectedNumbers, actualNumbers, "Remove method should remove element at the last index!");
        }

        [Test]
        public void TestAdd_ShouldThrowAnExceptionWhenTryingToRemoveElementsWhenArrayIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();

            }, "Remove should throw an exception when trying remove when there are no elements in the array!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void TestFetch_ShouldReturnTheCorrectItems(int[] numbers)
        {
            this.db = new Database(numbers);

            int[] expectedItems = numbers;
            int[] actualNumbers = this.db.Fetch();

            CollectionAssert.AreEqual(expectedItems, actualNumbers, "Fetch method should return the correct inserted items!");
        }
    }
}
