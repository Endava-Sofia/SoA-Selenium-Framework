using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly DashboardPage _dashboardPage;
        private readonly SettingsModel _settingsModel;
        private readonly ScenarioContext _context;

        public DashboardSteps(ScenarioContext scenario, DashboardPage dashboardPage, SettingsModel model)
        {
            this._dashboardPage = dashboardPage;
            this._settingsModel = model;
            this._context = scenario;
        }

        [Then("I should see the logged user in the main header")]
        public void ThenIShouldSeeTheLoggedUserInTheMainHeader()
        {
            _dashboardPage.VerifyLoggedUserEmailIs(_settingsModel.Email);
            _dashboardPage.VerifyUsernameIs(_settingsModel.Username);
        }

        [Then("I should see the created user is logged successfully")]
        public void ThenIShouldSeeTheCreatedUserLoggedSuccessfully()
        {
            var registeredUser = this._context.Get<UserModel>(ContextConstants.RegisteredUser);
            this._dashboardPage.VerifyLoggedUserEmailIs(registeredUser.Email);
            this._dashboardPage.VerifyUsernameIs($"{registeredUser.FirstName} {registeredUser.Surname}");
        }

        [When("I should see the logged registered user")]
        public void WhenIShouldSeeTheLoggedRegisteredUser()
        {
            _dashboardPage.VerifyLoggedUserEmailIs(_context.Get<string>("userMail"));
        }

        [Then("I should be able to logout successfully")]
        [When("I should be able to logout successfully")]
        public void ThenIShouldBeAbleToLogoutSuccessfully()
        {
            _dashboardPage.Logout();
        }

        [When("I open Users list page")]
        public void WhenIOpenUsersListPage()
        {
            _dashboardPage.OpenUsersMenu();
        }
    }
}