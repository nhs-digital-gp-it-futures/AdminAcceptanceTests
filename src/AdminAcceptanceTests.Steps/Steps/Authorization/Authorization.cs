namespace AdminAcceptanceTests.Steps.Steps.Authorization
{
    using AdminAcceptanceTests.Steps.Utils;
    using FluentAssertions;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    [Binding]
    public class Authorization : TestBase
    {
        public Authorization(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a User is not logged in")]
        public void GivenThatAUserIsNotLoggedIn()
        {
            Test.Pages.Homepage.ClickLoginButton();
        }

        [When(@"a User provides a (true|false) username")]
        public void WhenAUserProvidesATrueUsername(bool usernameCorrect)
        {
            if (usernameCorrect)
            {
                var user = Test.AdminUser;
                Test.Pages.Authorization.EnterUsername(user.UserName);
            }
        }

        [When(@"a User provides a (true|false) password")]
        public void WhenAUserProvidesATruePassword(bool passwordCorrect)
        {
            if (passwordCorrect)
            {
                var user = Test.AdminUser;
                Test.Pages.Authorization.EnterPassword(user.PasswordHash);
            }
        }

        [When(@"a User provides recognised authentication details to login locally")]
        public void WhenAUserProvidesRecognisedAuthenticationDetailsToLoginLocally()
        {
            var user = Test.AdminUser;
            Test.Pages.Authorization.EnterUsername(user.UserName);
            Test.Pages.Authorization.EnterPassword(user.PasswordHash);
            Test.Pages.Authorization.Login();
        }

        [Given(@"that a User enters an invalid e-mail address and password")]
        public void GivenThatAUserEntersAnInvalidE_MailAddressAndPassword()
        {
            Test.Pages.Authorization.EnterUsername("Invalid@Email.test");
            Test.Pages.Authorization.EnterPassword("Password123");
        }

        [Then(@"the User will be logged in")]
        public void ThenTheUserWillBeLoggedIn()
        {
            Test.Pages.Authorization.WaitForLoginPageToNotBeDisplayed();
            Test.Pages.Homepage.WaitUntilLoggedInFully();
        }

        [Then(@"the User will not be logged in")]
        public void ThenTheUserWillNotBeLoggedIn()
        {
            Test.Pages.Authorization.Login();
            Test.Pages.Authorization.WaitForErrorSummaryToBeDisplayed();
        }

        [Then(@"the User will be informed the login attempt was unsuccessful Email (.*), password (.*)")]
        public void ThenTheUserWillBeInformedTheLoginAttemptWasUnsuccessful(bool email, bool password)
        {
            if (!email)
            {
                Test.Driver.FindElement(By.CssSelector("[data-valmsg-for=EmailAddress]")).Displayed.Should().BeTrue();
            }

            if (!password)
            {
                Test.Driver.FindElement(By.CssSelector("[data-valmsg-for=Password]")).Displayed.Should().BeTrue();
            }
        }

        [Then(@"the User is informed that they entered invalid credentials")]
        public void ThenTheUserIsInformedThatTheyEnteredInvalidCredentials()
        {
            Test.Pages.Authorization.InvalidCredentialsErrorDisplayed().Should().BeTrue();
        }

        [Given(@"the User is logged in")]
        public void GivenTheUserIsLoggedIn()
        {
            GivenThatAUserIsNotLoggedIn();
            WhenAUserProvidesRecognisedAuthenticationDetailsToLoginLocally();
            Test.Pages.Authorization.WaitForLoginPageToNotBeDisplayed();
        }

        [When(@"the User logs out")]
        public void WhenTheUserLogsOut()
        {
            Test.Pages.Homepage.LogOut();
        }

        [Then(@"the User is logged out")]
        public void ThenTheUserIsLoggedOut()
        {
            Test.Pages.Homepage.WaitUntilLoggedOutFully();
        }
    }
}
