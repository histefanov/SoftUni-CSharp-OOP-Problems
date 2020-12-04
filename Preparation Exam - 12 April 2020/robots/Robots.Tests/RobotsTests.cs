namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("Pesho", 100)]
        [TestCase("Ico", 5000)]
        public void RobotConstructor_ShouldWorkAsExpected(string name, int maximumBattery)
        {
            var robot = new Robot(name, maximumBattery);

            Assert.AreEqual(robot.Name, name);
            Assert.AreEqual(robot.MaximumBattery, maximumBattery);
            Assert.AreEqual(robot.Battery, maximumBattery);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void RobotManagerConstructor_ShouldWorkAsExpected(int capacity)
        {
            var robotManager = new RobotManager(capacity);

            Assert.AreEqual(robotManager.Capacity, capacity);
            Assert.AreEqual(robotManager.Count, 0);
        }

        [Test]
        public void CapacitySetter_ShouldThrowArgExc_WhenValueLessThanZero()
        {
            Assert.Throws<ArgumentException>(
                () => new RobotManager(-1));
        }

        [Test]
        [TestCase("Pesho")]
        public void Add_ShouldThrowInvOpExc_WhenRobotNameAlreadyExists(string name)
        {
            var robotManager = new RobotManager(2);
            var robot = new Robot(name, 100);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(robot));
        }

        [Test]
        public void Add_ShouldThrowInvOpExc_WhenCapacityIsReached()
        {
            var robotManager = new RobotManager(1);
            var robot1 = new Robot("Ico", 10);
            var robot2 = new Robot("Gosho", 8);

            robotManager.Add(robot1);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(robot2));
        }

        [Test]
        public void Add_ShouldIncreaseCount_WhenRobotIsAdded()
        {
            var robotManager = new RobotManager(1);
            robotManager.Add(new Robot("Ico", 25));

            var expectedCount = 1;
            var actualCount = robotManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Remove_ShouldThrowInvOpExc_WhenRobotDoesNotExist()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Remove("Pesho"));
        }

        [Test]
        public void Remove_ShouldRemoveRobot_WhenNameIsFound()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("ICO", 25500);

            robotManager.Add(robot);
            robotManager.Remove("ICO");

            Assert.AreEqual(robotManager.Count, 0);
        }

        [Test]
        public void Work_ShouldThrowInvOpExc_WhenRobotDoesNotExist()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("Pesho", "Cook", 100));
        }

        [Test]
        public void Work_ShouldThrowInvOpExc_WhenRobotBatteryNotEnough()
        {
            var robotManager = new RobotManager(1);

            robotManager.Add(new Robot("Toshko", 50));

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("Toshko", "Wash the dishes", 60));
        }

        [Test]
        public void Work_ShouldReduceRobotBattery_WhenJobIsDone()
        {
            var robotManager = new RobotManager(1);
            var initialBattery = 200;
            var batteryUsage = 60;
            var robot = new Robot("Ico", initialBattery);

            robotManager.Add(robot);
            robotManager.Work("Ico", "Fix the pipes", batteryUsage);
            var expectedResult = initialBattery - batteryUsage;
            var actualResult = robot.Battery;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Charge_ShouldThrowInvOpExc_WhenRobotIsNotFound()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Charge("Pesho"));
        }

        [Test]
        public void Charge_ShouldIncreaseBattery()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("Ico", 50);
            robotManager.Add(robot);

            robotManager.Work("Ico", "4isti", 25);
            robotManager.Charge("Ico");

            Assert.AreEqual(robot.Battery, 50);
        }
    }
}
