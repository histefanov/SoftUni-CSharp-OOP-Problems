using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Acer", "Predator", 3000);
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void ComputerManagerConstructor_ShouldWorkAsExpected()
        {
            var manager = new ComputerManager();
            var pc = new Computer("Lenovo", "ThinkPad", 4000);

            var expectedCount = 0;
            var actualCount = computerManager.Count;

            Assert.AreEqual("Lenovo", pc.Manufacturer);
            Assert.AreEqual("ThinkPad", pc.Model);
            Assert.AreEqual(4000, pc.Price);

            Assert.AreEqual(expectedCount, actualCount);
            CollectionAssert.IsEmpty(manager.Computers);
        }

        [Test]
        public void AddComputer_ShouldThrowArgNullExc_WhenAddingNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputer_ShouldThrowArgExc_WhenAddingExistingComputer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(
                () => computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_ShouldWorkAsExpected_WhenValidComputerIsAdded()
        {
            var dell = new Computer("Dell", "Inspire", 2900);
            computerManager.AddComputer(dell);

            Assert.That(computerManager.Computers, Has.Member(dell));
            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        [TestCase("Dell", null)]
        [TestCase(null, "Inspire")]
        public void GetComputer_ShouldThrowArgNullExc_WhenModelOrManufacturerIsNull(
            string manufacturer, string model)
        {
            Assert.Throws<ArgumentNullException>(
                () => this.computerManager.GetComputer(manufacturer, model));
        }

        [Test]
        public void GetComputer_ShouldThrowArgExc_WhenNoMatch()
        {
            Assert.Throws<ArgumentException>(
                () => computerManager.GetComputer("Lenovo", "IdeaPad 510"));
        }

        [Test]
        public void GetComputer_ShouldWorkAsExpected_WhenMatchIsFound()
        {
            computerManager.AddComputer(computer);

            var expectedResult = computer;
            var actualResult = computerManager.GetComputer("Acer", "Predator");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveComputer_ShouldThrowArgExc_WhenNoMatchIsFound()
        {
            Assert.Throws<ArgumentException>(
                () => computerManager.RemoveComputer("Apple", "MacPro"));        
        }

        [Test]
        public void RemoveComputer_ShouldWorkAsExpected()
        {
            computerManager.AddComputer(computer);
            computerManager.RemoveComputer("Acer", "Predator");

            Assert.That(computerManager.Computers, !Has.Member(computer));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldThrowArgNullExc_WhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnExpectedCollection_WhenManufacturerExists()
        {
            var computer2 = new Computer("Acer", "Aspire", 5000);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);

            var expectedResult = new List<Computer>() { computer, computer2 };
            var actualResult = computerManager.GetComputersByManufacturer("Acer");

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnEmptyCollection_WhenNoComputerMatchesManufacturer()
        {
            computerManager.AddComputer(computer);

            var result = computerManager.GetComputersByManufacturer("Asus");

            CollectionAssert.IsEmpty(result);
        }
    }
}