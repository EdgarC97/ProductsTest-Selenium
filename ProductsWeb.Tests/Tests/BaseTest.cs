using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;

namespace ProductsWeb.Tests
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver Driver;
        protected string BaseUrl = "https://localhost:5141"; // Ajusta según tu configuración

        [OneTimeSetUp]
        public void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
        }

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void Cleanup()
        {
            Dispose();
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}

