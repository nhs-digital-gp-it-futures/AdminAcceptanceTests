using AdminAcceptanceTests.Steps.Utils;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.Authorization
{
    [Binding]
    public class Authorization : TestBase
    {

        public Authorization(UITest test, ScenarioContext context) : base(test, context)
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
                var user = EnvironmentVariables.AdminUser();
                Test.Pages.Authorization.EnterUsername(user.Username);
            }
        }

        [When(@"a User provides a (true|false) password")]
        public void WhenAUserProvidesATruePassword(bool passwordCorrect)
        {
            if (passwordCorrect)
            {
                var user = EnvironmentVariables.AdminUser();
                Test.Pages.Authorization.EnterPassword(user.Password);
            }
        }

        [When(@"a User provides recognised authentication details to login locally")]
        public void WhenAUserProvidesRecognisedAuthenticationDetailsToLoginLocally()
        {
            var user = EnvironmentVariables.AdminUser();
            Test.Pages.Authorization.EnterUsername(user.Username);
            Test.Pages.Authorization.EnterPassword(user.Password);
            Test.Pages.Authorization.Login();
        }

        [Then(@"the User will be logged in")]
        public void ThenTheUserWillBeLoggedIn()
        {
            Test.Pages.Homepage.LoginLogoutLinkText().Should().Be("Log out");
        }

        [Then(@"the User will not be logged in")]
        public void ThenTheUserWillNotBeLoggedIn()
        {
            Test.Pages.Authorization.Login();
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

        [Given(@"the User is logged in")]
        public void GivenTheUserIsLoggedIn()
        {
            GivenThatAUserIsNotLoggedIn();
            WhenAUserProvidesRecognisedAuthenticationDetailsToLoginLocally();
        }

        [When(@"the User logs out")]
        public void WhenTheUserLogsOut()
        {
            Test.Pages.Homepage.LogOut();
        }

        [Then(@"the User is logged out")]
        public void ThenTheUserIsLoggedOut()
        {
            Test.Pages.Homepage.LoginLogoutLinkText().Should().BeEquivalentTo("Log in");
        }

    }
}
