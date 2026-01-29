using Reqnroll;
using SeleniumFramework.Models;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class DashboardSteps
    {
        private readonly SettingsModel _settingsModel;
        private readonly DashboardPage _dashboardPage;

        public DashboardSteps(DashboardPage dashboardPage, SettingsModel model)
        {
            this._dashboardPage = dashboardPage;
            this._settingsModel = model;
        }

        [Then("I should see the logged user in the main header")]
        public void ThenIShouldSeeTheLoggedUserInTheMainHeader()
        {
            this._dashboardPage.VerifyLoggedUserEmailIs(_settingsModel.Email);
            this._dashboardPage.VerifyUsernameIs(_settingsModel.Username);
        }

        [Then("I should be able to logout successfully")]
        public void ThenIShouldBeAbleToLogoutSuccessfully()
        {
            this._dashboardPage.Logout();
        }
    }
}
