using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;

namespace ProductsWeb.Tests.Pages
{
    // Represents the Products page in the web application as a Page Object.
    public class ProductsPage
    {
        // Private field to hold the Selenium WebDriver instance.
        private readonly IWebDriver _driver;

        // Constructor that accepts a WebDriver instance and initializes page elements.
        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            // Initialize all elements decorated with PageFactory attributes.
            PageFactory.InitElements(driver, this);
        }

        // Property to locate the "Create New" button on the page.
        // Uses WebDriverWait to ensure the element is present before returning it.
        private IWebElement CreateNewButton
        {
            get
            {
                // Wait up to 10 seconds for the "createNew" element to be available.
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                return wait.Until(d => d.FindElement(By.Id("createNew")));
            }
        }

        // Property to locate the product table on the page.
        // Uses WebDriverWait to ensure the table is present before returning it.
        private IWebElement ProductTable
        {
            get
            {
                // Wait up to 10 seconds for the table element to be available using a CSS selector.
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                return wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            }
        }

        // Navigates the browser to the Products page URL.
        public void NavigateToProducts()
        {
            // Change the URL to navigate to the products list.
            _driver.Navigate().GoToUrl("http://localhost:5047/products");
        }

        // Clicks on the "Create New" button to start creating a new product.
        public void ClickCreateNew()
        {
            // Use the CreateNewButton property to locate and click the button.
            CreateNewButton.Click();
        }

        // Checks if a product with the specified name is listed in the product table.
        public bool IsProductListed(string productName)
        {
            // Find all rows in the product table.
            var rows = ProductTable.FindElements(By.TagName("tr"));
            // Return true if any row's text contains the given product name.
            return rows.Any(row => row.Text.Contains(productName));
        }

        // Clicks the "Edit" button for a product with the specified name.
        public void ClickEditProduct(string productName)
        {
            // Find the row corresponding to the product name.
            var row = FindProductRow(productName);
            // If the row is found, locate the edit button (using a CSS selector) and click it.
            row?.FindElement(By.CssSelector(".btn-edit"))?.Click();
        }

        // Clicks the "Delete" button for a product with the specified name.
        public void ClickDeleteProduct(string productName)
        {
            // Find the row corresponding to the product name.
            var row = FindProductRow(productName);
            // If the row is found, locate the delete button (using a CSS selector) and click it.
            row?.FindElement(By.CssSelector(".btn-delete"))?.Click();
        }

        // Helper method to find a row in the product table that contains the specified product name.
        private IWebElement? FindProductRow(string productName)
        {
            // Get all rows in the product table.
            var rows = ProductTable.FindElements(By.TagName("tr"));
            // Return the first row that contains the product name in its text, or null if not found.
            return rows.FirstOrDefault(row => row.Text.Contains(productName));
        }
    }
}
