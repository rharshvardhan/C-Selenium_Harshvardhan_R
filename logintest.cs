using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using AventStack.ExtentReports;

using System.Threading;
using TestProject2;

namespace ConsoleApp2
{
    public class LoginTests : BaseTest
    {
        private ExtentReports extent;
        private ExtentTest test;
        [OneTimeSetUp]
        public void SetupReport()
        {
            extent = ReportManager.GetInstance();
        }
        [Test]

        public void LoginAsValidUser()
        {
            test = extent.CreateTest("LoginAsValidUser"); 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "admin123");
         test.Pass("Login successful with valid user");

            Thread.Sleep(10000);
        }



        [Test]

        public void LoginAsInValidUser()
        {
            test = extent.CreateTest("LoginAsInValidUser"); 

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "invalid123");
            string errorText = loginpage.getErrorText();
            test.Pass("Login attempt with invalid user completed");
            Assert.That(errorText, Is.EqualTo("Invalid credentials"), "Error message should be invalid credentials");
            Thread.Sleep(10000);
        }
        public void Dispose()
        {

        }
         [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush(); 
        }
    }
}