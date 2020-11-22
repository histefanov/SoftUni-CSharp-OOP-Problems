using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const string EXAMPLE_USERNAME = "Pesho";
        private const long EXAMPLE_ID = 1;

        private Person person;
        private ExtendedDatabase extendedDatabase;


        [SetUp]
        public void Setup()
        {
            this.person = new Person(EXAMPLE_ID, EXAMPLE_USERNAME);
            this.extendedDatabase = new ExtendedDatabase(this.person);
        }

        [Test]
        public void PersonConstructorShouldWork()
        {
            Assert.AreEqual(this.person.UserName, EXAMPLE_USERNAME);
            Assert.AreEqual(this.person.Id, EXAMPLE_ID);
        }

        [Test]
        public void DatabaseConstructorShouldWork()
        {
            Assert.AreEqual(extendedDatabase.FindById(EXAMPLE_ID), this.person);
        }

        [Test]
        public void DatabaseConstructorShouldThrowExceptionIfRangeCountIsTooBig()
        {
            var inputData = new Person[17];

            Assert.Throws<ArgumentException>(
                () => this.extendedDatabase =
                new ExtendedDatabase(inputData));
        }

        [Test]
        public void AddingPersonToDatabaseShouldWorkProperly()
        {
            var newPerson = new Person(111, "Tosho");
            this.extendedDatabase.Add(newPerson);

            Assert.AreEqual(newPerson, extendedDatabase.FindById(111));
        }

        [Test]
        public void AddingPersonToFullCollectionShouldThrowException()
        {
            this.extendedDatabase =
                new ExtendedDatabase(
                    new Person(1, "Pesho1"),
                    new Person(2, "Pesho2"),
                    new Person(3, "Pesho3"),
                    new Person(4, "Pesho4"),
                    new Person(5, "Pesho5"),
                    new Person(6, "Pesho6"),
                    new Person(7, "Pesho7"),
                    new Person(8, "Pesho8"),
                    new Person(9, "Pesho9"),
                    new Person(10, "Pesho10"),
                    new Person(11, "Pesho11"),
                    new Person(12, "Pesho12"),
                    new Person(13, "Pesho13"),
                    new Person(14, "Pesho14"),
                    new Person(15, "Pesho15"),
                    new Person(16, "Pesho16"));

            Assert.Throws<InvalidOperationException>(
                () => this.extendedDatabase.Add(new Person(112, "Tosho2")));
        }

        [Test]
        public void AddingPersonWithExistingUserNameShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.extendedDatabase.Add(new Person(2, "Pesho")));
        }

        [Test]
        public void AddingPersonWithExistingIdShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.extendedDatabase.Add(new Person(1, "Gosho")));
        }

        [Test]
        public void RemovingPersonShouldWork()
        {
            this.extendedDatabase.Add(new Person(2, "Gosho"));

            extendedDatabase.Remove();

            Assert.That(extendedDatabase.Count == 1);
        }

        [Test]
        public void RemovingPersonFromEmptyCollectionShouldThrowException()
        {
            this.extendedDatabase.Remove();

            Assert.Throws<InvalidOperationException>(
                () => this.extendedDatabase.Remove());
        }

        [Test]
        public void FindByUsernameShouldWorkProperly()
        {
            var foundPerson = this.extendedDatabase.FindByUsername(EXAMPLE_USERNAME);

            Assert.AreEqual(foundPerson, this.person);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrowArgumentNullException(string username)
        {
            Assert.Throws<ArgumentNullException>(
                () => this.extendedDatabase.FindByUsername(username));
        }

        [Test]
        [TestCase("NonExistantUser")]
        public void FindByUsernameShouldThrowExceptionIfUserNotPresent(string username)
        {
            Assert.Throws<InvalidOperationException>(
                () => this.extendedDatabase.FindByUsername(username));
        }

        [Test]
        public void FindByIdShouldWorkProperly()
        {
            var foundPerson = this.extendedDatabase.FindById(EXAMPLE_ID);

            Assert.AreEqual(foundPerson, this.person);
        }

        [Test]
        [TestCase(-1)]
        public void FindByIdShouldNotWorkWithNegativeNumbers(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => this.extendedDatabase.FindById(id));
        }

        [Test]
        [TestCase(8888)]
        public void FindByIdShouldShouldThrowExceptionIfUserNotPresent(long id)
        {
            Assert.Throws<InvalidOperationException>(
                () => this.extendedDatabase.FindById(id));
        }
    }
}