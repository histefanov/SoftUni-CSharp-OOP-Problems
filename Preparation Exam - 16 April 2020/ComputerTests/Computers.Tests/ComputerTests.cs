namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerConstructor_ShouldCreateInstanceAsExpected()
        {
            var computer = new Computer("Mac");
            var computerParts = new List<Part>();

            Assert.AreEqual(computer.Name, "Mac");
            CollectionAssert.AreEqual(computer.Parts, computerParts);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ComputerNameSetter_ShouldThrowArgExc_WhenValueIsNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Computer(name));
        }

        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(20, 10, 15, 45)]
        [TestCase(85, 1, 4, 90)]
        public void TotalPrice_ShouldReturnExpectedValue(
            int price1, int price2, int price3, int expectedTotalPrice)
        {
            var computer = new Computer("Atanasov");
            computer.AddPart(new Part("cpu", price1));
            computer.AddPart(new Part("gpu", price2));
            computer.AddPart(new Part("ram", price3));

            var actualTotalPrice = computer.TotalPrice;

            Assert.AreEqual(expectedTotalPrice, actualTotalPrice);
        }

        [Test]
        public void AddPart_ShouldThrowInvOpExc_WhenPartIsNull()
        {
            var computer = new Computer("Asus");

            Assert.Throws<InvalidOperationException>(
                () => computer.AddPart(null));
        }

        [Test]
        public void AddPart_ShouldWorkAsExpected()
        {
            var computer = new Computer("Razer");
            var part = new Part("CPU", 1500);
            computer.AddPart(part);

            Assert.That(computer.Parts, Has.Member(part));            
        }

        [Test]
        public void RemovePart_ShouldRemovePartAndReturnTrue_WhenPartExists()
        {
            var computer = new Computer("Razer");
            var part = new Part("CPU", 1500);
            computer.AddPart(part);

            bool isSuccessful = computer.RemovePart(part);

            Assert.That(isSuccessful);
            CollectionAssert.DoesNotContain(computer.Parts, part);
        }

        [Test]
        public void RemovePart_ShouldReturnFalse_WhenPartDoesNotExist()
        {
            var computer = new Computer("Dell");
            var part = new Part("Engine", 900);

            bool isSuccessful = computer.RemovePart(part);

            Assert.That(!isSuccessful);
        }

        [Test]
        public void GetPart_ShouldReturnNull_WhenPartDoesNotExist()
        {
            var computer = new Computer("Dell");

            var result = computer.GetPart("cpu");

            Assert.IsNull(result);
        }

        [Test]
        public void GetPart_ShouldReturnPart_WhenPartExists()
        {
            var computer = new Computer("Dell");
            var part = new Part("ssd", 900);
            computer.AddPart(part);

            var result = computer.GetPart("ssd");

            Assert.AreSame(result, part);
        }
    }
}