using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
namespace TestProject2
{
    public class BaseTest
    {
        protected IWebDriver? driver;
        protected WebDriverWait? wait;

        [SetUp]
        public void Setup()
        {
            string browser = "chrome";

            if (browser.ToLower() == "chrome")
                driver = new ChromeDriver();
            else if (browser.ToLower() == "edge")
                driver = new EdgeDriver();
            else
                throw new Exception("Unsupported browser");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }


        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
