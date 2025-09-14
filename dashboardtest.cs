using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject2;
using AventStack.ExtentReports;
namespace SeleniumDemo
{
    public class DashboardTests : BaseTest
    {
        private ExtentReports extent;
        private ExtentTest test;
        private string url;
        private string username;
        private string password;
      
        public static readonly By DashboardHeader = By.XPath("//h6[text()='Dashboard']");
        public static readonly By TimeAtWorkWidget = By.XPath("//p[text()='Time at Work']");
        public static readonly By PunchStatus = By.CssSelector(".orangehrm-attendance-card-state");
        public static readonly By UserDropdown = By.CssSelector(".oxd-userdropdown-tab");
        public static readonly By LogoutLink = By.XPath("//a[text()='Logout']");

        [OneTimeSetUp]
        public void SetupReport()
        {
            extent = ReportManager.GetInstance();
        }

        [SetUp]
        public void ReadExcelData()
        {
            
            url = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 0);
            username = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 1);
            password = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 2);

            // FOR SQL data fetching uncomment below and comment above Excel lines
            /* string url = SqlUtils.GetValue("SELECT Url, Username, Password FROM TestData WHERE Id=1", "Url");
            string username = SqlUtils.GetValue("SELECT Url, Username, Password FROM TestData WHERE Id=1", "Username");
            string password = SqlUtils.GetValue("SELECT Url, Username, Password FROM TestData WHERE Id=1", "Password"); */

            // For debugging
            // Console.WriteLine("Excel Data Read:");
            // Console.WriteLine("URL: '" + url + "'");
            // Console.WriteLine("Username: '" + username + "'");
            // Console.WriteLine("Password: '" + password + "'");
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("URL read from Excel is empty. Check your TestData.xlsx file.");
        
        }

        [Test]
        public void TC01_OpenDashboardAndCaptureHeaderText()
        {
            test = extent.CreateTest("TC01_OpenDashboardAndCaptureHeaderText");
            Console.WriteLine($"URL={url}, User={username}, Pass={password}");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin(url, username, password);
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
            loginpage.DoLogin(url, username, password);
            DashboardPage dashboardpage = new DashboardPage(driver);
            IWebElement widget = dashboardpage.GetWidgetVisible();
            IWebElement punch = dashboardpage.GetPunchVisible();
            test.Pass("Time at Work widget and Punch status validated successfully");
            Assert.That(widget.Displayed, Is.True);
            Assert.That(punch.Displayed, Is.True, "Punch status should be visible");
        }

        [Test]
        public void TC03_PerformLogoutAndValidateReturnToLogin()
        {
            test = extent.CreateTest("TC03_PerformLogoutAndValidateReturnToLogin");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin(url, username, password);
            DashboardPage dashboardpage = new DashboardPage(driver);
            dashboardpage.Logout();
            test.Pass("Logout successful");
        }

        [Test]
        public void TC04_PerformAddUser()
        {
            string firstName = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 4);
            string lastName = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 5);  
            string empId = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 6);
            test = extent.CreateTest("TC04_PerformAddUser");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin(url, username, password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(DashboardPage.PIMModule)).Click();
            wait.Until(e => e.FindElement(DashboardPage.AddEmployee)).Click();
            driver.FindElement(DashboardPage.firstName).SendKeys(firstName);
            driver.FindElement(DashboardPage.lastName).SendKeys(lastName);
            driver.FindElement(DashboardPage.empId).SendKeys(empId);
            driver.FindElement(DashboardPage.saveBtn).Click();
            test.Pass("User added successfully");
        
        }

        [Test]
        public void TC05_PerformTimesheetCheck()
        {
            string sampleName = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 7);
            test = extent.CreateTest("TC05_PerformTimesheetCheck");
            LoginPage loginpage = new LoginPage(driver);
            loginpage.DoLogin(url, username, password);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(DashboardPage.time)).Click();
            driver.FindElement(DashboardPage.tinesheetInput).SendKeys(sampleName);
            wait.Until(e => e.FindElement(DashboardPage.viewButton)).Click();
            test.Pass("Timesheet viewed successfully");
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }
    }
}
