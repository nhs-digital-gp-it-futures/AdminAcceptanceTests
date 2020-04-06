using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
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
            Test.Pages.Authorization.EnterUsername(user.UserName);
            Test.Pages.Authorization.EnterPassword(user.PasswordHash);
            Test.Pages.Authorization.Login();
            Test.Pages.Homepage.LoginLogoutLinkText().Should().Be("Log out");
        }

        [Given(@"I am on a random organisation user account dashboard")]
        public void GivenIAmOnARandomOrganisationUserAccountDashboard()
        {
            GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse();
            var OrganisationDashboardSteps = new OrganisationDashboard.OrganisationsDashboard(Test, Context);
            OrganisationDashboardSteps.WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage();
            OrganisationDashboardSteps.WhenAnOrganisationIsSelected();
            OrganisationDashboardSteps.ThenTheUserAccountsDashboardForThatOrganisationIsDisplayed();
            string ODSCode = Test.Pages.UserAccountsDashboard.GetODSCode();
            Context.Add("ODSCode", ODSCode);
        }

        [When(@"a specific organisation is selected")]
        public void WhenASpecificOrganisationIsSelected()
        {
            var organisation = (Organisation)Context["Organisation"];
            Test.Pages.OrganisationDashboard.SelectNamedOrganisation(organisation.Name);
            Test.Pages.UserAccountsDashboard.OrganisationNameMatches(organisation.Name);
        }

        [When(@"they select to view a user's details from the organisation's user accounts dashboard")]
        public void WhenTheySelectToViewAUserSUserAccountsDashboard()
        {
            new CommonSteps(Test, Context).GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse();
            var OrganisationDashboardSteps = new OrganisationDashboard.OrganisationsDashboard(Test, Context);
            OrganisationDashboardSteps.WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage();
            OrganisationDashboardSteps.ThenTheAuthorityUserIsDirectedToTheOrganisationsDashboard();
            WhenASpecificOrganisationIsSelected();
            Test.Pages.UserAccountsDashboard.ViewUserLinksDisplayed().Should().BeTrue();
            var targetUser = (User)Context["BuyingUser"];
            Test.Pages.UserAccountsDashboard.ClickUserLink(User.ConcatDisplayName(targetUser));
        }
    }
}
