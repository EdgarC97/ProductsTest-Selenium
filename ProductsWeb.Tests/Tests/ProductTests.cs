using NUnit.Framework;
using OpenQA.Selenium;
using ProductsWeb.Tests.Pages;
using System;

namespace ProductsWeb.Tests
{
    // Test fixture for product-related tests.
    [TestFixture]
    public class ProductTests : BaseTest
    {
        // Page objects for the Products page and Create Product page.
        private ProductsPage _productsPage;
        private CreateProductPage _createPage;

        // Setup method to initialize page objects before each test.
        [SetUp]
        public void SetupPages()
        {
            // Instantiate the Products page using the WebDriver from BaseTest.
            _productsPage = new ProductsPage(Driver);
            // Instantiate the Create Product page using the same WebDriver.
            _createPage = new CreateProductPage(Driver);
        }

        // Test to verify that creating a new product adds it to the products list.
        [Test]
        public void CreateProduct_ShouldAddNewProduct()
        {
            // Arrange: Navigate to the Products page and click the "Create New" button.
            _productsPage.NavigateToProducts();
            _productsPage.ClickCreateNew();

            // Generate a unique product name using current ticks to avoid duplicates.
            string productName = "Test Product " + DateTime.Now.Ticks;

            // Act: Use the CreateProductPage to fill out and submit the product creation form.
            _createPage.CreateProduct(
                name: productName,
                description: "Test Description",
                price: 99.99m,
                stock: 10
            );

            // Assert: Navigate back to the Products page and verify that the new product is listed.
            _productsPage.NavigateToProducts();
            Assert.That(_productsPage.IsProductListed(productName), Is.True,
                "New product should appear in the list");
        }

        // Test to verify that the products list is displayed on the Products page.
        [Test]
        public void ProductsList_ShouldDisplayProducts()
        {
            // Act: Navigate to the Products page.
            _productsPage.NavigateToProducts();

            // Assert: Find the products table using its CSS selector and verify it's displayed.
            var table = Driver.FindElement(By.CssSelector("table.table"));
            Assert.That(table.Displayed, Is.True, "Products table should be visible");
        }
    }
}
