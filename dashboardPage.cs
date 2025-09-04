using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    public class DashboardPage
    {


        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public static readonly By DashboardHeader = By.XPath("//h6[text()='Dashboard']");
        public static readonly By TimeAtWorkWidget = By.XPath("//p[text()='Time at Work']");
        public static readonly By PunchStatus = By.CssSelector(".orangehrm-attendance-card-state");
        public static readonly By UserDropdown = By.CssSelector(".oxd-userdropdown-tab");
        public static readonly By LogoutLink = By.XPath("//a[text()='Logout']");

        public static readonly By PIMModule = By.XPath("//span[text()='PIM']/parent::a"); //new one
        public static readonly By AddEmployee = By.XPath("//button[contains(.,'Add')]"); //new one
        public static readonly By firstName = By.XPath("//input[@name='firstName']"); //new one
        public static readonly By lastName = By.XPath("//input[@name='lastName']"); //new one
        public static readonly By empId = By.XPath("//label[text()='Employee Id']/../following-sibling::div//input[@class='oxd-input oxd-input--active']"); // new one
        public static readonly By saveBtn = By.XPath("//button[normalize-space()='Save']"); // new one
        public static readonly By time = By.XPath("//span[text()='Time']");
        public static readonly By tinesheetInput = By.XPath("//input[@placeholder='Type for hints...']"); // new one
        public static readonly By viewButton = By.XPath("//button[text()=' View ']");

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public string GetHeaderText()
        {
            IWebElement header = wait.Until(ExpectedConditions.ElementIsVisible(DashboardHeader));
            Console.WriteLine("Dashboard header text: " + header.Text); 
            return header.Text;
        }

        public IWebElement GetWidgetVisible()
        {
            IWebElement widget = wait.Until(ExpectedConditions.ElementIsVisible(TimeAtWorkWidget));
            return widget;
        }

        public IWebElement GetPunchVisible()
        {
            IWebElement widget = wait.Until(ExpectedConditions.ElementIsVisible(PunchStatus));
            return widget;
        }

        public void Logout()
        {

            IWebElement dropdown = wait.Until(ExpectedConditions.ElementIsVisible(UserDropdown));
            dropdown.Click();

            IWebElement logout = wait.Until(ExpectedConditions.ElementIsVisible(LogoutLink));
            logout.Click();
        }
    }
}