using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_ShouldWork()
        {
            var vault = new BankVault();

            var expectedCellCount = 12;
            var expectedVaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            var actualVaultCells = vault.VaultCells;

            CollectionAssert.AreEqual(expectedVaultCells, actualVaultCells);
            Assert.AreEqual(expectedVaultCells["A1"], actualVaultCells["A1"]);
            Assert.IsNull(actualVaultCells["A1"]);
            Assert.AreEqual(expectedCellCount, vault.VaultCells.Count);
        }

        [Test]
        public void AddItem_ShouldThrow_WhenCellDoesntExist()
        {
            var vault = new BankVault();

            Assert.Throws<ArgumentException>(
                () => vault.AddItem("H5", new Item("Pesho", "Coins")));
        }

        [Test]
        public void AddItem_ShouldThrow_WhenCellTaken()
        {
            var vault = new BankVault();
            var item = new Item("Pesho", "Gold");

            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(
                () => vault.AddItem("A1", new Item("Ico", "Silver")));
        }

        [Test]
        public void AddItem_ShouldThrow_IfItemExists()
        {
            var vault = new BankVault();
            var item = new Item("Pesho", "Laptop");

            vault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(
                () => vault.AddItem("A2", item));

            // check for diff item with same name
        }

        [Test]
        public void AddItem_ShouldWork()
        {
            var vault = new BankVault();
            var item = new Item("Pesho", "Watch");

            var expectedResult = $"Item:{item.ItemId} saved successfully!";
            var actualResult = vault.AddItem("A1", item);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreSame(item, vault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItem_ShouldThrow_WhenCellDoesntExist()
        {
            var vault = new BankVault();

            Assert.Throws<ArgumentException>(
                () => vault.RemoveItem("H1", new Item("Ico", "Happiness")));
        }

        [Test]
        public void RemoveItem_ShouldThrow_WhenCellEmpty()
        {
            var vault = new BankVault();

            Assert.Throws<ArgumentException>(
                () => vault.RemoveItem("A1", new Item("Ico", "Happiness")));
        }

        [Test]
        public void RemoveItem_ShouldThrow_WhenItemDoesntMatch()
        {
            var vault = new BankVault();
            var item = new Item("Pesho", "Watch");
            var itemToRemove = new Item("Ico", "Stealer");

            vault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(
                () => vault.RemoveItem("A1", itemToRemove));
        }

        [Test]
        public void RemoveItem_ShouldWork()
        {
            var vault = new BankVault();
            var item = new Item("Pesho", "Watch");

            vault.AddItem("B1", item);
            var actualResult = vault.RemoveItem("B1", item);
            var expectedResult = $"Remove item:{item.ItemId} successfully!";
            Item expectedCellContent = null;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.IsNull(vault.VaultCells["B1"]);
            Assert.AreSame(expectedCellContent, vault.VaultCells["B1"]);
        }
    }
}