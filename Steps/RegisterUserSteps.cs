using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class RegisterUserSteps
    {
        private IWebDriver _driver;
        private readonly ScenarioContext _context;
        private readonly SettingsModel _settingsModel;

        public RegisterUserSteps(ScenarioContext context, IWebDriver driver, SettingsModel model)
        {
            this._context = context;
            this._driver = driver;
            this._settingsModel = model;
        }

        [Given("I register new user with valid details")]
        public void GivenIRegisterNewUserWithValidDetails()
        {
            var registerPage = new RegisterUserPage(_driver);
            var registeredUser = registerPage.RegisterNewUser();
            _context.Add("RegisteredUser", registeredUser);
        }
    }
}
