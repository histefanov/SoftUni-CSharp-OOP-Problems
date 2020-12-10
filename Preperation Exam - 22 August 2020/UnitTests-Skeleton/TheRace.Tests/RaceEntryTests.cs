using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitCarConstructor_ShouldCreateExpectedInstance()
        {
            var car = new UnitCar("Opel", 120, 1800);

            Assert.AreEqual("Opel", car.Model);
            Assert.AreEqual(120, car.HorsePower);
            Assert.AreEqual(1800, car.CubicCentimeters);
        }

        [Test]
        public void UnitDriverConstructor_ShouldCreateExpectedInstance()
        {
            var car = new UnitCar("Opel", 120, 1800);
            var driver = new UnitDriver("Pesho", car);

            Assert.AreEqual("Pesho", driver.Name); ;
            Assert.AreSame(car, driver.Car);
        }

        [Test]
        public void UnitDriverNameSetter_ShouldThrowExc_WhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new UnitDriver(null, new UnitCar("Opel", 120, 1800)));
        }

        [Test]
        public void Constructor_ShouldCreateExpectedInstance()
        {
            var raceEntry = new RaceEntry();

            Assert.That(raceEntry.Counter == 0);
        }

        [Test]
        public void AddDriver_ShouldThrowInvOpExc_WhenDriverIsNull()
        {
            var raceEntry = new RaceEntry();
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(
                () => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ShouldThrowInvOpExc_WhenAlreadyDriverExists()
        {
            var raceEntry = new RaceEntry();
            var driver = new UnitDriver("Pesho", new UnitCar("Mazda", 200, 2000));

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ShouldWorkAsExpected()
        {
            var raceEntry = new RaceEntry();
            var driver = new UnitDriver("Pesho", new UnitCar("Mazda", 200, 2000));

            var expectedOutputMsg = "Driver Pesho added in race.";
            var actualOutputMsg = raceEntry.AddDriver(driver);

            var expectedCount = 1;
            var actualCount = raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedOutputMsg, actualOutputMsg);
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldThrowInvOpExc_WhenCountIsLessThanMin()
        {
            var raceEntry = new RaceEntry();
            var driver = new UnitDriver("Pesho", new UnitCar("Mazda", 200, 2000));
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        [TestCase(100, 200, 300)]
        [TestCase(650, 320, 99)]
        [TestCase(50, 90, 101)]
        public void CalculateAverageHorsePower_ShouldProduceExpectedResult(
            int hp1, int hp2, int hp3)
        {
            var raceEntry = new RaceEntry();
            var driver1 = new UnitDriver("Pesho", new UnitCar("Mazda", hp1, 2000));
            var driver2 = new UnitDriver("Gosho", new UnitCar("VW", hp2, 2000));
            var driver3 = new UnitDriver("Ico", new UnitCar("BMW", hp3, 2000));

            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);

            var expectedResult = new List<UnitDriver>() { driver1, driver2, driver3 }
                .Select(d => d.Car.HorsePower)
                .Average();
            var actualResult = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}