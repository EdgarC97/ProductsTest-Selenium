using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Linq;

namespace ProductsWeb.Tests.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver _driver;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebElement CreateNewButton
        {
            get
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                return wait.Until(d => d.FindElement(By.Id("createNew")));
            }
        }

        private IWebElement ProductTable
        {
            get
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                return wait.Until(d => d.FindElement(By.CssSelector("table.table")));
            }
        }

        public void NavigateToProducts()
        {
            _driver.Navigate().GoToUrl("http://localhost:5047/products");
        }

        public void ClickCreateNew()
        {
            CreateNewButton.Click();
        }

        public bool IsProductListed(string productName)
        {
            var rows = ProductTable.FindElements(By.TagName("tr"));
            return rows.Any(row => row.Text.Contains(productName));
        }

        public void ClickEditProduct(string productName)
        {
            var row = FindProductRow(productName);
            row?.FindElement(By.CssSelector(".btn-edit"))?.Click();
        }

        public void ClickDeleteProduct(string productName)
        {
            var row = FindProductRow(productName);
            row?.FindElement(By.CssSelector(".btn-delete"))?.Click();
        }

        private IWebElement? FindProductRow(string productName)
        {
            var rows = ProductTable.FindElements(By.TagName("tr"));
            return rows.FirstOrDefault(row => row.Text.Contains(productName));
        }
    }
}