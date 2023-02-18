using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProjectSeleniuem
{
    [TestClass]
    public class HomaPage
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeLoggedIn()
        {
            _driver = new EdgeDriver();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var loginButtonLocator = By.Id("login-button");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10f));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();
        }
        [TestCleanup]
        public void TestCleanUP()
        {
            _driver.Quit();
        }
    }
}