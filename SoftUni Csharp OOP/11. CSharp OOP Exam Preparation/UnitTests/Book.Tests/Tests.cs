namespace Book.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Reflection;
    using System.Collections.Generic;

    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("Rich Dad Poor Dad", "Robert Kiyosaki");
        }

        [Test]
        public void TestConstructor()
        {
            string expectedTitle = "Rich Dad Poor Dad";
            string expectedAuthor = "Robert Kiyosaki";

            string actualTitle = book.BookName;
            string actualAuthor = book.Author;

            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [Test]
        public void TestConstructorInitializationOfCollections()
        {
            FieldInfo[] fields = book.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

            FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "footnote");

            Dictionary<int, string> expectedDictionary = new Dictionary<int, string>();

            Dictionary<int, string> actualDictionary = collectionField.GetValue(book) as Dictionary<int, string>;

            CollectionAssert.AreEqual(expectedDictionary, actualDictionary);
        }

        [Test]
        public void TestNameGetter()
        {
            string expectedName = "Rich Dad Poor Dad";
            string actualName = book.BookName;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase("")]
        [TestCase(null)]
        public void NameSetterShouldThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "Radko");
            });
        }

        [Test]
        public void TestAuthorGetter()
        {
            string expectedAuthor = "Robert Kiyosaki";
            string actualAuthor = book.Author;

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [TestCase("")]
        [TestCase(null)]
        public void AuthorSetterShouldThrowException(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Rich Dad", authorName);
            });
        }

        [Test]
        public void TestCountGetter()
        {
            int expectedCount = 0;
            int actualCount = book.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void TestCountGetterAfterAddingToCollection()
        {
            book.AddFootnote(1, "Text1");

            int expectedCount = 1;
            int actualCount = book.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddFootnote()
        {
            book.AddFootnote(1, "Text1");
            book.AddFootnote(2, "Text2");
            book.AddFootnote(3, "Text3");
            book.AddFootnote(4, "Text4");

            Dictionary<int, string> expectedDictionary = new Dictionary<int, string>()
            {
                [1] = "Text1",
                [2] = "Text2",
                [3] = "Text3",
                [4] = "Text4"
            };

            FieldInfo[] fields = book.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(field => field.IsPrivate).ToArray();

            FieldInfo collectionField = fields.FirstOrDefault(field => field.Name == "footnote");

            Dictionary<int, string> actualDictionary = collectionField.GetValue(book) as Dictionary<int, string>;

            CollectionAssert.AreEqual(expectedDictionary, actualDictionary);
        }

        [Test]
        public void TestAddShouldThrowException()
        {
            book.AddFootnote(1, "Text1");
            book.AddFootnote(2, "Text2");
            book.AddFootnote(3, "Text3");
            book.AddFootnote(4, "Text4");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(2, "Text1");
            });
        }

        [Test]
        public void TestFindFootnote()
        {
            book.AddFootnote(1, "Text1");
            book.AddFootnote(2, "Text2");
            book.AddFootnote(3, "Text3");
            book.AddFootnote(4, "Text4");

            string expectedFootnote = "Footnote #1: Text1";

            string actualFootnote = book.FindFootnote(1);

            Assert.AreEqual(expectedFootnote, actualFootnote);
        }


        [Test]
        public void TestFindFootnoteShouldThrowException()
        {
            book.AddFootnote(1, "Text1");
            book.AddFootnote(2, "Text2");
            book.AddFootnote(3, "Text3");
            book.AddFootnote(4, "Text4");

            Assert.Throws<InvalidOperationException>(() =>
            {
                string footnote = book.FindFootnote(5);
            });
        }

        [Test]
        public void TestAlterFootnote()
        {
            book.AddFootnote(1, "Text1");
            book.AddFootnote(2, "Text2");
            book.AddFootnote(3, "Text3");
            book.AddFootnote(4, "Text4");

            book.AlterFootnote(1, "I'm Jose Mourinho");

            string expectedFootnote = "Footnote #1: I'm Jose Mourinho";

            string actualFootnote = book.FindFootnote(1);

            Assert.AreEqual(expectedFootnote, actualFootnote);
        }

        [Test]
        public void TestAlterFootnoteShouldThrowException()
        {
            book.AddFootnote(1, "Text1");
            book.AddFootnote(2, "Text2");
            book.AddFootnote(3, "Text3");
            book.AddFootnote(4, "Text4");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(11111, "I'm Jose Mourinho");
            });
        }
    }
}