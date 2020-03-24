using AdminAcceptanceTests.Steps.Utils;
using FluentAssertions;
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
            Test.Pages.Homepage.ClickLoginButton();
            var user = EnvironmentVariables.AdminUser();
            Test.Pages.Authorization.EnterUsername(user.Username);
            Test.Pages.Authorization.EnterPassword(user.Password);
            Test.Pages.Authorization.Login();
            Test.Pages.Homepage.LoginLogoutLinkText().Should().Be("Log out");
        }

    }
}
