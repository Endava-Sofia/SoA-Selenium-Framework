using Reqnroll;
using SeleniumFramework.DatabaseOperations.Operations;
using SeleniumFramework.Models;
using SeleniumFramework.Models.Factories;
using SeleniumFramework.Pages;
using SeleniumFramework.Utilities;
using SeleniumFramework.Utilities.Constants;

namespace SeleniumFramework.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private readonly ScenarioContext _context;
        private readonly RegisterPage _registerPage;
        private readonly LoginPage _loginPage;
        private readonly UserOperations _userOperations;
        private readonly IUserFactory _userFactory;


        public RegisterSteps(IUserFactory userFactory, ScenarioContext context, LoginPage loginPage, RegisterPage registerPage, UserOperations userOperations)
        {
            this._userFactory = userFactory;
            this._context = context;
            this._loginPage = loginPage;
            this._registerPage = registerPage;
            this._userOperations = userOperations;
        }


        [Given("I register new user with valid details")]
        public void GivenIRegisterNewUserWithValidDetails()
        {
            this._loginPage.ClickRegisterNewUser();

            // Extract as Factory pattern and showcase builder pattern for user creation
            var registeredUser = _userFactory.CreateDefault();
            _context.Add(ContextConstants.RegisteredUser, registeredUser);

            _registerPage.RegisterNewUser(registeredUser);

            Retry.Until(() =>
            {
                var doUserExist = this._userOperations.CheckIfUserExistsByEmail(registeredUser.Email);
                if (doUserExist == false)
                    throw new RetryException("Registerd User is not found in the database.");
            });
        }

        [When("I click on T&C button")]
        public void GivenIClickOnTCButton()
        {
            _registerPage.TermsAndConditionsClick();
        }

        [When("I click on Register button")]
        public void GivenIClickOnRegisterButton()
        {
            _registerPage.ClickRegisterButton();
        }

        [Given("I navigate to the register page and sign up with a new user")]
        public void GivenINavigateToTheRegisterPageAndSignUpWithANewUser()
        {
            GivenIFillInUserRegistrationForm();
            GivenIClickOnTCButton();
            GivenIClickOnRegisterButton();
        }

        [When("I fill in user registration form")]
        public void GivenIFillInUserRegistrationForm()
        {
            var user = _registerPage.GetUserInformation();
            _context.Add("userMail", user.Email);
            _context.Add("userPassword", user.Password);
            _registerPage.PopulateRegistrationForm(user);
        }
    }
}
