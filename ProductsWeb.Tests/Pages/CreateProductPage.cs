using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace ProductsWeb.Tests.Pages
{
    public class CreateProductPage
    {
        private readonly IWebDriver _driver;

        public CreateProductPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Locators
        private IWebElement NameInput => _driver.FindElement(By.Id("productName"));
        private IWebElement DescriptionInput => _driver.FindElement(By.Id("productDescription"));
        private IWebElement PriceInput => _driver.FindElement(By.Id("productPrice"));
        private IWebElement StockInput => _driver.FindElement(By.Id("productStock"));
        private IWebElement SubmitButton => _driver.FindElement(By.Id("submitButton"));

        // Actions
        public void FillProductForm(string name, string description, decimal price, int stock)
        {
            NameInput.SendKeys(name);
            DescriptionInput.SendKeys(description);
            PriceInput.SendKeys(price.ToString());
            StockInput.SendKeys(stock.ToString());
        }

        public void SubmitForm()
        {
            SubmitButton.Click();
        }

        public void CreateProduct(string name, string description, decimal price, int stock)
        {
            FillProductForm(name, description, price, stock);
            SubmitForm();
        }
    }
}

