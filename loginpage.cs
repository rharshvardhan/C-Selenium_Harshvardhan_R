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
    public class LoginPage
    {
        private static readonly By UsernameField = By.Name("username");
        private static readonly By PasswordField = By.Name("password");
        private static readonly By LoginButton = By.CssSelector(".orangehrm-login-button");
        private static readonly By PagerMarker = By.CssSelector(".orangehrm-login-form");
        private static readonly By ErrorMessage = By.CssSelector(".oxd-alert-content--error");

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
       
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
       

        public string getErrorText()
        {
            IWebElement errorElement = wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessage));
            string errorText = errorElement.Text;
            return errorText;
        }
        
        public void DoLogin(String username, String passwrd)
        {

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            IWebElement uname = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
            uname.SendKeys(username);

            IWebElement password = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            password.SendKeys(passwrd);

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}