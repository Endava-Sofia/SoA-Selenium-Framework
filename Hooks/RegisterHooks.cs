using OpenQA.Selenium;
using Reqnroll;
using SeleniumFramework.DatabaseOperations.Operations;

namespace SeleniumFramework.Hooks
{
    [Binding]
    public class RegisterHooks
    {
        private readonly IWebDriver _driver;

        public RegisterHooks(IWebDriver webDriver)
        {
            this._driver = webDriver;
        }

        [AfterScenario]
        public void CloserBrowser()
        {
            _driver.Quit();
        }

        [AfterScenario(Order = 9999)]
        public void DeleteCurrentUser()
        {
            //_userOperations.DeleteUserWithEmail("idimitrov@automation.com");
        }
    }
}
