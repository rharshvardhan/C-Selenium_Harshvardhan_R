using NUnit.Framework;
using AventStack.ExtentReports;
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
            string url = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 0);
            string username = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 1);
            string password = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 2);

            // FOR SQL data fetching uncomment below and comment above Excel lines
            /*  string url = SQLHelper.GetURL();
              string username = SQLHelper.GetUsername();
              string password = SQLHelper.GetPassword(); */
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.DoLogin(url, username, password);
            test.Pass("Login successful with valid user");
            
        }

        [Test]
        public void LoginAsInvalidUser()
        {
          test = extent.CreateTest("LoginAsInvalidUser");
          string  url = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 0);
          string username = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 1);
          string password = ExcelUtils.ReadCell("TestData.xlsx", "Sheet1", 1, 3);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.DoLogin(url, username, password);
            string errorText = loginPage.GetErrorText();
            test.Pass("Login attempt with invalid user completed");
            Assert.That(errorText, Is.EqualTo("Invalid credentials"));
            
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            extent.Flush();
        }
    }
}
