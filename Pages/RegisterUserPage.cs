using OpenQA.Selenium;
using SeleniumFramework.Models;

namespace SeleniumFramework.Pages
{
    public class RegisterUserPage
    {
        private readonly IWebDriver _driver;

        public RegisterUserPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public UserModel RegisterNewUser()
        {
            var user = new UserModel
            {
                FirstName = "John",
                Surname = "Doe",
                Email = $"john.doe{Guid.NewGuid()}@example.com",
                Password = "SecureP@ssw0rd",
                Country = "USA",
                City = "New York"
            };

            // Fill in the registration form

            return user;
        }
    }
}
