using CarManager;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Tests
{
    public class CarTests
    {
        private const string MOCK_MAKE = "Volkswagen";
        private const string MOCK_MODEL = "Golf";
        private const double MOCK_FUEL_CONSUMPTION = 7.5;
        private const double MOCK_FUEL_CAPACITY = 50;
        private const double MOCK_INITIAL_FUEL_AMOUNT = 0;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(
                MOCK_MAKE, 
                MOCK_MODEL, 
                MOCK_FUEL_CONSUMPTION, 
                MOCK_FUEL_CAPACITY);
        }

        [Test]
        public void Car_Constructor_ShouldCreateExpectedInstance()
        {
            Assert.AreEqual(this.car.Make, MOCK_MAKE);
            Assert.AreEqual(this.car.Model, MOCK_MODEL);
            Assert.AreEqual(this.car.FuelConsumption, MOCK_FUEL_CONSUMPTION);
            Assert.AreEqual(this.car.FuelCapacity, MOCK_FUEL_CAPACITY);
            Assert.AreEqual(this.car.FuelAmount, MOCK_INITIAL_FUEL_AMOUNT);

            Assert.IsInstanceOf(typeof(Car), this.car);
            Assert.DoesNotThrow(() => this.car.Refuel(1));
            Assert.DoesNotThrow(() => this.car.Drive(0));
        }

        [Test]
        public void Car_MakeGetter_ShouldReturnExpectedResult()
        {
            var expectedResult = MOCK_MAKE;
            var actualResult = this.car.Make;

            Assert.That(actualResult == expectedResult);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Car_MakeSetter_ShouldThrowExceptionIfNullOrEmpty(string invalidMake)
        {
            Assert.Throws<ArgumentException>(
                () => this.car = 
                new Car(invalidMake, MOCK_MODEL, MOCK_FUEL_CONSUMPTION, MOCK_FUEL_CAPACITY));
        }

        [Test]
        public void Car_ModelGetter_ShouldReturnExpectedResult()
        {
            var expectedResult = MOCK_MODEL;
            var actualResult = this.car.Model;

            Assert.That(actualResult == expectedResult);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Car_ModelSetter_ShouldThrowExceptionIfNullOrEmpty(string invalidModel)
        {
            Assert.Throws<ArgumentException>(
                () => this.car =
                new Car(MOCK_MAKE, invalidModel, MOCK_FUEL_CONSUMPTION, MOCK_FUEL_CAPACITY));
        }

        [Test]
        public void Car_FuelConsumptionGetter_ShouldReturnExpectedResult()
        {
            var expectedResult = MOCK_FUEL_CONSUMPTION;
            var actualResult = this.car.FuelConsumption;

            Assert.That(actualResult == expectedResult);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(Double.MinValue)]
        public void Car_FuelConsumptionSetter_ShouldThrowExceptionIfZeroOrNegative(double invalidFuelConsumption)
        {
            Assert.Throws<ArgumentException>(
                () => this.car =
                new Car(MOCK_MAKE, MOCK_MODEL, invalidFuelConsumption, MOCK_FUEL_CAPACITY));
        }

        [Test]
        public void Car_FuelCapacityGetter_ShouldReturnExpectedResult()
        {
            var expectedResult = MOCK_FUEL_CAPACITY;
            var actualResult = this.car.FuelCapacity;

            Assert.That(actualResult == expectedResult);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(Double.MinValue)]
        public void Car_FuelCapacitySetter_ShouldThrowExceptionIfNegative(double invalidFuelCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => this.car =
                new Car(MOCK_MAKE, MOCK_MODEL, MOCK_FUEL_CONSUMPTION, invalidFuelCapacity));
        }

        [Test]
        public void Car_FuelAmountGetter_ShouldReturnExpectedResult()
        {
            var expectedResult = MOCK_INITIAL_FUEL_AMOUNT;
            var actualResult = this.car.FuelAmount;

            Assert.That(actualResult == expectedResult);
        }

        [Test]
        [TestCase(-0.01)]
        [TestCase(-20)]
        public void Car_FuelAmountSetter_ShouldThrowExceptionIfNegative(double fuelAmount)
        {
            Type type = typeof(Car);
            var instance = Activator.CreateInstance(type,
                MOCK_MAKE, 
                MOCK_MODEL, 
                MOCK_FUEL_CONSUMPTION, 
                MOCK_FUEL_CAPACITY);

            var fuelAmountPropInfo = type.GetProperty("FuelAmount");

            Assert.Throws<TargetInvocationException>(
                () => fuelAmountPropInfo.SetValue(instance, fuelAmount));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(MOCK_FUEL_CAPACITY)]
        public void Car_Refuel_ShouldWorkProperly(double fuelToRefuel)
        {
            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(this.car.FuelAmount, fuelToRefuel);
        }

        [Test]
        [TestCase(MOCK_FUEL_CAPACITY + 0.01)]
        [TestCase(MOCK_FUEL_CAPACITY + 100)]
        [TestCase(Double.MaxValue)]
        public void Car_Refuel_ShouldNotOverfillTank(double fuelToRefuel)
        {
            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(this.car.FuelAmount, this.car.FuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-0.01)]
        [TestCase(-50)]
        [TestCase(Double.MinValue)]
        public void Car_Refuel_ShouldNotAcceptZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(
                () => this.car.Refuel(fuelToRefuel));
        }

        [Test]
        [TestCase(20)]
        [TestCase(50)]
        [TestCase(0)]
        public void Car_Drive_ShouldWorkProperly(double distance)
        {
            this.car.Refuel(MOCK_FUEL_CAPACITY);
            double initialFuelAmount = this.car.FuelAmount;
            this.car.Drive(distance);

            double expectedFuelUsage = (distance / 100) * this.car.FuelConsumption;
            double actualFuelUsage = initialFuelAmount - this.car.FuelAmount;

            Assert.AreEqual(expectedFuelUsage, actualFuelUsage);
        }

        [Test]
        [TestCase(5000)]
        [TestCase(101)]
        public void Car_Drive_ShouldThrowExceptionWhenInsufficientFuelAmount(double distance)
        {
            this.car.Refuel(7.5);

            Assert.Throws<InvalidOperationException>(
                () => this.car.Drive(distance));
        }

        [Test]
        public void TestRefuelWithZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }
    }
}