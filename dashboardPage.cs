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