using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace ProductsWeb.Tests.Pages
{
    // Represents the page object for the "Create Product" page.
    public class CreateProductPage
    {
        // Private field to hold the Selenium WebDriver instance.
        private readonly IWebDriver _driver;

        // Constructor receives the WebDriver instance and initializes page elements.
        public CreateProductPage(IWebDriver driver)
        {
            _driver = driver;
            // Initialize all elements decorated with attributes in this page using PageFactory.
            PageFactory.InitElements(driver, this);
        }

        // Locators for the web elements on the Create Product page.
        // Each property finds an element by its ID.

        // Locator for the product name input field.
        private IWebElement NameInput => _driver.FindElement(By.Id("productName"));
        // Locator for the product description input field.
        private IWebElement DescriptionInput => _driver.FindElement(By.Id("productDescription"));
        // Locator for the product price input field.
        private IWebElement PriceInput => _driver.FindElement(By.Id("productPrice"));
        // Locator for the product stock input field.
        private IWebElement StockInput => _driver.FindElement(By.Id("productStock"));
        // Locator for the submit button to create the product.
        private IWebElement SubmitButton => _driver.FindElement(By.Id("submitButton"));

        // Actions that can be performed on the Create Product page.

        /// <summary>
        /// Fills in the product creation form with the provided data.
        /// </summary>
        /// <param name="name">The product name.</param>
        /// <param name="description">The product description.</param>
        /// <param name="price">The product price.</param>
        /// <param name="stock">The product stock quantity.</param>
        public void FillProductForm(string name, string description, decimal price, int stock)
        {
            // Send the product name to the name input field.
            NameInput.SendKeys(name);
            // Send the product description to the description input field.
            DescriptionInput.SendKeys(description);
            // Convert the price to string and send it to the price input field.
            PriceInput.SendKeys(price.ToString());
            // Convert the stock quantity to string and send it to the stock input field.
            StockInput.SendKeys(stock.ToString());
        }

        /// <summary>
        /// Submits the product creation form by clicking the submit button.
        /// </summary>
        public void SubmitForm()
        {
            // Click on the submit button to submit the form.
            SubmitButton.Click();
        }

        /// <summary>
        /// Fills out and submits the form to create a new product.
        /// </summary>
        /// <param name="name">The product name.</param>
        /// <param name="description">The product description.</param>
        /// <param name="price">The product price.</param>
        /// <param name="stock">The product stock quantity.</param>
        public void CreateProduct(string name, string description, decimal price, int stock)
        {
            // Fill out the product creation form.
            FillProductForm(name, description, price, stock);
            // Submit the filled form.
            SubmitForm();
        }
    }
}
