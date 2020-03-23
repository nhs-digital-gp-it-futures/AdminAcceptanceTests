using AdminAcceptanceTests.Steps.Utils;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps
{
    [Binding]
    public sealed class CommonSteps : TestBase
    {
        public CommonSteps(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Given(@"that an Authority User has logged in on Public Browse")]
        public void GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse()
        {
            _test.Pages.Homepage.ClickLoginButton();
            _test.Pages.Homepage.PageDisplayed();
            var user = EnvironmentVariables.AdminUser();
            _test.Pages.Authorization.EnterUsername(user.Username);
            _test.Pages.Authorization.EnterPassword(user.Password);
            _test.Pages.Authorization.Login();
            _test.Pages.Homepage.LoginLogoutLinkText().Should().Be("Log out");
        }

    }
}
