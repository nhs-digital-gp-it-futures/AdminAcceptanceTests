using AdminAcceptanceTests.Steps.Utils;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
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
            _test.Pages.Homepage.ClickLoginButton();
        }

        [When(@"a User provides a (true|false) username")]
        public void WhenAUserProvidesATrueUsername(bool usernameCorrect)
        {
            if (usernameCorrect)
            {
                var user = EnvironmentVariables.AdminUser();
                _test.Pages.Authorization.EnterUsername(user.Username);
            }
        }

        [When(@"a User provides a (true|false) password")]
        public void WhenAUserProvidesATruePassword(bool passwordCorrect)
        {
            if (passwordCorrect)
            {
                var user = EnvironmentVariables.AdminUser();
                _test.Pages.Authorization.EnterPassword(user.Password);
            }
        }

        [When(@"a User provides recognised authentication details to login locally")]
        public void WhenAUserProvidesRecognisedAuthenticationDetailsToLoginLocally()
        {
            var user = EnvironmentVariables.AdminUser();
            _test.Pages.Authorization.EnterUsername(user.Username);
            _test.Pages.Authorization.EnterPassword(user.Password);
            _test.Pages.Authorization.Login();
        }

        [Then(@"the User will be logged in")]
        public void ThenTheUserWillBeLoggedIn()
        {
            _test.Pages.Homepage.LoginLogoutLinkText().Should().Be("Log out");
        }

        [Then(@"the User will not be logged in")]
        public void ThenTheUserWillNotBeLoggedIn()
        {
            _test.Pages.Authorization.Login();
        }

        [Then(@"the User will be informed the login attempt was unsuccessful Email (.*), password (.*)")]
        public void ThenTheUserWillBeInformedTheLoginAttemptWasUnsuccessful(bool email, bool password)
        {
            if (!email)
            {
                _test.Driver.FindElement(By.CssSelector("[data-valmsg-for=EmailAddress]")).Displayed.Should().BeTrue();
            }

            if (!password)
            {
                _test.Driver.FindElement(By.CssSelector("[data-valmsg-for=Password]")).Displayed.Should().BeTrue();
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
            _test.Pages.Homepage.LogOut();
        }

        [Then(@"the User is logged out")]
        public void ThenTheUserIsLoggedOut()
        {
            _test.Pages.Homepage.LoginLogoutLinkText().Should().BeEquivalentTo("Log in");
        }

    }
}
