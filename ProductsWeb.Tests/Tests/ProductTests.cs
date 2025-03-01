using NUnit.Framework;
using OpenQA.Selenium;
using ProductsWeb.Tests.Pages;
using System;

namespace ProductsWeb.Tests
{
    [TestFixture]
    public class ProductTests : BaseTest
    {
        private ProductsPage _productsPage;
        private CreateProductPage _createPage;

        [SetUp]
        public void SetupPages()
        {
            _productsPage = new ProductsPage(Driver);
            _createPage = new CreateProductPage(Driver);
        }

        [Test]
        public void CreateProduct_ShouldAddNewProduct()
        {
            // Arrange
            _productsPage.NavigateToProducts();
            _productsPage.ClickCreateNew();

            string productName = "Test Product " + DateTime.Now.Ticks;

            // Act
            _createPage.CreateProduct(
                name: productName,
                description: "Test Description",
                price: 99.99m,
                stock: 10
            );

            // Assert
            _productsPage.NavigateToProducts();
            Assert.That(_productsPage.IsProductListed(productName), Is.True,
                "New product should appear in the list");
        }

        [Test]
        public void ProductsList_ShouldDisplayProducts()
        {
            // Act
            _productsPage.NavigateToProducts();

            // Assert
            var table = Driver.FindElement(By.CssSelector("table.table"));
            Assert.That(table.Displayed, Is.True, "Products table should be visible");
        }
    }
}

