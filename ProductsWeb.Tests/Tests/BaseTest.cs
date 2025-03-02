using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;

namespace ProductsWeb.Tests
{
    // BaseTest class that provides setup and teardown functionality for Selenium WebDriver tests.
    // Implements IDisposable to ensure proper cleanup of WebDriver resources.
    public class BaseTest : IDisposable
    {
        // Protected WebDriver instance available to derived test classes.
        protected IWebDriver Driver;
        // Base URL for the application under test.
        protected string BaseUrl = "https://localhost:5141";

        // OneTimeSetUp method runs once before any tests are executed.
        // It ensures that the required ChromeDriver is available and up-to-date.
        [OneTimeSetUp]
        public void SetUpDriver()
        {
            // Download and setup the ChromeDriver using WebDriverManager.
            new DriverManager().SetUpDriver(new ChromeConfig());
        }

        // Setup method that runs before each test.
        // It initializes the WebDriver, maximizes the browser window, and sets implicit wait time.
        [SetUp]
        public void Setup()
        {
            // Create a new instance of ChromeDriver.
            Driver = new ChromeDriver();
            // Maximize the browser window for a consistent test view.
            Driver.Manage().Window.Maximize();
            // Set implicit wait timeout for element searches to 10 seconds.
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        // TearDown method that runs after each test.
        // It calls the Dispose method to properly close and clean up the WebDriver instance.
        [TearDown]
        public void Cleanup()
        {
            Dispose();
        }

        // Dispose method to clean up resources.
        // It quits the WebDriver session and releases any associated resources.
        public void Dispose()
        {
            // Quit the WebDriver session if it exists.
            Driver?.Quit();
            // Dispose the WebDriver instance if it exists.
            Driver?.Dispose();
        }
    }
}
