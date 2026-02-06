using OpenQA.Selenium;
using SeleniumFramework.Extensions;

namespace SeleniumFramework.Pages
{
    public class DashboardPage : BasePage
    {
        private IWebElement LoggedUserAnchor => _driver.FindElement(By.XPath("//a[@id='navbarDropdown']"));
        private IWebElement UsernameHeader => _driver.FindElement(By.XPath("//div[contains(@class, 'container-fluid')]/h1"));
        private IWebElement UsersButton => _driver.FindElement(By.XPath("//div[@id='navbar']//a[contains(text(), 'Users')]"));
        private IWebElement LogoutButton => _driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
        
        public DashboardPage(IWebDriver driver) :base(driver)
        {
        }

        public void VerifyLoggedUserEmailIs(string expectedUserEmail)
        {
            string actualUserEmail = this.LoggedUserAnchor.Text.Trim();

            Assert.That(actualUserEmail, Is.EqualTo(expectedUserEmail));
        }

        public void VerifyUsernameIs(string username)
        {
            string headerText = this.UsernameHeader.Text.Trim();
            Assert.That(headerText, Does.Contain(username));
        }

        public void Logout()
        {
            this.LoggedUserAnchor.Click();
            _driver.WaitUntilElementIsClickable(this.LogoutButton);
            this.LogoutButton.Click();
        }

        public void OpenUsersMenu()
        {
            UsersButton.Click();
        }
    }
}
