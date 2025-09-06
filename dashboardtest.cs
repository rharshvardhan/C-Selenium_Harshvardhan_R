using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TestProject2;
using AventStack.ExtentReports;

namespace SeleniumDemo
{
    public class DashboardTests : BaseTest
    {
        // Element locators
        public static readonly By UsernameField = By.Name("username");
        public static readonly By PasswordField = By.Name("password");
        public static readonly By LoginButton = By.CssSelector(".orangehrm-login-button");
        public static readonly By DashboardHeader = By.XPath("//h6[text()='Dashboard']");
        public static readonly By TimeAtWorkWidget = By.XPath("//p[text()='Time at Work']");
        public static readonly By PunchStatus = By.CssSelector(".orangehrm-attendance-card-state");
        public static readonly By UserDropdown = By.CssSelector(".oxd-userdropdown-tab");
        public static readonly By LogoutLink = By.XPath("//a[text()='Logout']");

        private ExtentReports extent;
        private ExtentTest test;
        [OneTimeSetUp]
        public void SetupReport()
        {
            extent = ReportManager.GetInstance();
        }

        [Test]
        public void TC04_PerformAddUser()
        {

            test = extent.CreateTest("TC04_PerformAddUser");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "admin123");

            wait.Until(e => e.FindElement(DashboardPage.PIMModule)).Click();
            Thread.Sleep(5000);
            wait.Until(e => e.FindElement(DashboardPage.AddEmployee)).Click();
            Thread.Sleep(5000);
            driver.FindElement(DashboardPage.firstName).SendKeys("Harsh");
            Thread.Sleep(5000);
            driver.FindElement(DashboardPage.lastName).SendKeys("Vardhan");
            Thread.Sleep(5000);
            driver.FindElement(DashboardPage.empId).SendKeys("12345");
            Thread.Sleep(5000);

            driver.FindElement(DashboardPage.saveBtn).Click();
            test.Pass("User added successfully");
            Thread.Sleep(5000);

        }
        [Test]
        public void TC05_PerformTimesheetCheck()
        {
            test = extent.CreateTest("TC05_PerformTimesheetCheck");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "admin123");

            wait.Until(e => e.FindElement(DashboardPage.time)).Click();
            Thread.Sleep(5000);
            driver.FindElement(DashboardPage.tinesheetInput).SendKeys("manda akhil user");
            Thread.Sleep(5000);
            wait.Until(e => e.FindElement(DashboardPage.viewButton)).Click();
            test.Pass("Timesheet viewed successfully");

            Thread.Sleep(5000);
        }

        [Test]
        public void TC03_PerformLogoutAndValidateReturnToLogin()
        {
            test = extent.CreateTest("TC03_PerformLogoutAndValidateReturnToLogin");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "admin123");

            DashboardPage dashboardpage = new DashboardPage(driver);
            dashboardpage.Logout();
            Thread.Sleep(10000);
            test.Pass("Logout successful");
            Console.WriteLine("User successfully logged out.");

        }

        [Test]
        public void TC01_OpenDashboardAndCaptureHeaderText()
        {
            test = extent.CreateTest("TC01_OpenDashboardAndCaptureHeaderText");

            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "admin123");

            DashboardPage dashboardpage = new DashboardPage(driver);
            string headerText = dashboardpage.GetHeaderText();

            Assert.That(headerText, Is.EqualTo("Dashboard"));
            test.Pass("Dashboard header text validated successfully");
        }

        [Test]
        public void TC02_CaptureTimeAtWorkWidgetDetails()
        {
            test = extent.CreateTest("TC02_CaptureTimeAtWorkWidgetDetails");

            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin("Admin", "admin123");

            DashboardPage dashboardpage = new DashboardPage(driver);
            IWebElement widget = dashboardpage.GetWidgetVisible();
            IWebElement punch = dashboardpage.GetPunchVisible();
            test.Pass("Time at Work widget and Punch status validated successfully");
            Assert.That(widget.Displayed, Is.True);
            Assert.That(punch.Displayed, Is.True, "Punch status should be visible");


        }
        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush(); 
        }

    }
}