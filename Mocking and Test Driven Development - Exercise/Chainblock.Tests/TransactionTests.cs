using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        [TestCase(3745, TransactionStatus.Successful, "Pesho", "Gosho", 10.50)]
        [TestCase(22004, TransactionStatus.Unauthorized, "Filip", "Viktor", 1000000.00)]
        public void TransactionConstructor_ShouldCreateExpectedInstance_WhenValuesAreValid(
            int id, TransactionStatus status, string from, string to, double amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);

            Assert.AreEqual(transaction.Id, id);
            Assert.AreEqual(transaction.Status, status);
            Assert.AreEqual(transaction.From, from);
            Assert.AreEqual(transaction.To, to);
            Assert.AreEqual(transaction.Amount, amount);
        }

        [Test]
        public void TransactionIdSetter_ShouldThrowArgExc_WhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(-1, TransactionStatus.Failed, "Pesho", "Gosho", 10));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void TransactionFromSetter_ShouldThrowArgExc_WhenValueIsNullOrWhiteSpace(
            string from)
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(100, TransactionStatus.Failed, from, "Gosho", 10));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void TransactionToSetter_ShouldThrowArgExc_WhenValueIsNullOrWhiteSpace(
            string to)
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(100, TransactionStatus.Failed, "Pesho", to, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10.50)]
        public void TransactionAmountSetter_ShouldThrowArgExc_WhenValueIsZeroOrNegative(
            double amount)
        {
            Assert.Throws<ArgumentException>(
                () => new Transaction(100, TransactionStatus.Failed, "Pesho", "Gosho", amount));
        }
    }
}
