using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace TestProject2
{
    public class LoginPage
    {
        private static readonly By UsernameField = By.Name("username");
        private static readonly By PasswordField = By.Name("password");
        private static readonly By LoginButton = By.CssSelector(".orangehrm-login-button");
        private static readonly By ErrorMessage = By.CssSelector(".oxd-alert-content--error");

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public string GetErrorText()
        {
            IWebElement errorElement = wait.Until(ExpectedConditions.ElementIsVisible(ErrorMessage));
            return errorElement.Text;
        }

        public void DoLogin(string url, string username, string password)
        {
            driver.Navigate().GoToUrl(url);
            driver.FindElement(UsernameField).SendKeys(username);
            driver.FindElement(PasswordField).SendKeys(password);
            driver.FindElement(LoginButton).Click();
        }
    }
}
