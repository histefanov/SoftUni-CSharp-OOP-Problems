using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager storeManager;
        private Product product;

        [SetUp]
        public void Setup()
        {
            this.storeManager = new StoreManager();
            this.product = new Product("Laptop", 15, 1000);
        }

        [Test]
        public void Constructor_ShouldCreateExpectedInstance()
        {
            var storeManager = new StoreManager();

            CollectionAssert.IsEmpty(storeManager.Products);
            Assert.AreEqual(storeManager.Count, 0);
        }

        [Test]
        public void AddProduct_ShouldThrowArgNullExc_WhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.storeManager.AddProduct(null));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void AddProduct_ShouldThrowArgExc_WhenProductQuantityLessOrEqualThanZero(
            int quantity)
        {
            var product = new Product("Biskvitki", quantity, 2.50m);

            Assert.Throws<ArgumentException>(
                () => this.storeManager.AddProduct(product));
        }

        [Test]
        public void AddProduct_ShouldWorkAsExpected_WhenValidProductIsPassed()
        {
            this.storeManager.AddProduct(this.product);

            CollectionAssert.Contains(this.storeManager.Products, this.product);
            Assert.AreEqual(this.storeManager.Count, 1);
        }

        [Test]
        public void BuyProduct_ShouldThrowArgNullExc_WhenNoSuchProduct()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.storeManager.BuyProduct("NonExistingProduct", 10));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void BuyProduct_ShouldThrowArgExc_WhenInsufficientQuantity(int quantity)
        {
            this.storeManager.AddProduct(new Product("Lenovo", 4, 4));

            Assert.Throws<ArgumentException>(
                () => this.storeManager.BuyProduct("Lenovo", quantity));
        }

        [Test]
        public void BuyProduct_ShouldWorkAsExpected_WhenValidProductInfoIsPassed()
        {
            this.storeManager.AddProduct(this.product);

            var expectedPrice = 10000;
            var actualPrice = this.storeManager.BuyProduct("Laptop", 10);

            var expectedRemainingQty = 5;
            var actualRemainingQty = this.product.Quantity;

            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedRemainingQty, actualRemainingQty);
        }

        [Test]
        public void GetTheMostExpensiveProduct_ShouldReturnNull_IfStoreIsEmpty()
        {
            var result = this.storeManager.GetTheMostExpensiveProduct();
            Assert.IsNull(result);
        }

        [Test]
        public void GetTheMostExpensiveProduct_ShouldReturnExpectedProduct()
        {
            var expectedMostExpensiveProduct = new Product("iPhone", 10, 1899);
            this.storeManager.AddProduct(new Product("Mouse", 10, 25));
            this.storeManager.AddProduct(new Product("Keyboard", 10, 60));
            this.storeManager.AddProduct(new Product("Headset", 10, 99));
            this.storeManager.AddProduct(expectedMostExpensiveProduct);

            var result = this.storeManager.GetTheMostExpensiveProduct();

            Assert.AreSame(expectedMostExpensiveProduct, result);
        }
    }
}