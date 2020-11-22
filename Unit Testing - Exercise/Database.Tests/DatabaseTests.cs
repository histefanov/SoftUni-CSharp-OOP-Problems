using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[0])]
        public void CreatingNewDatabaseInstance(int[] data)
        {
            this.database = new Database.Database(data);
            var arr = this.database.Fetch();
            bool areEqual = true;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != arr[i])
                {
                    areEqual = false;
                }
            }

            Assert.That(areEqual, "Incorrect instance of Database class was created");
        }

        [Test]
        [TestCase(5)]
        [TestCase(0)]
        [TestCase(int.MaxValue)]
        public void AddingNumbersToDatabase(int number)
        {
            database.Add(number);

            Assert.AreEqual(database.Fetch()[^1], number,
                "Method did not add number at the end of the internal array");
        }

        [Test]
        [TestCase(1)]
        public void AddingNumbersToFullDatabase(int number)
        {
            this.database = new Database.Database(
                new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            Assert.Throws<InvalidOperationException>(
                () => this.database.Add(number), "Did not throw proper exception");
        }

        [Test]
        public void RemovingNumbersFromDatabase()
        {
            this.database = new Database.Database(new[] { 1, 2, 3 });
            int postOperationCount = this.database.Count;

            this.database.Remove();

            Assert.That(postOperationCount - 1 == this.database.Count,
                "Did not properly remove element");
        }

        [Test]
        public void RemovingNumbersFromEmptyDatabase()
        {
            this.database = new Database.Database(new int[0]);               

            Assert.Throws<InvalidOperationException>(
                () => this.database.Remove(),
                "Did not throw proper exception");
        }
    }
}