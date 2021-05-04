namespace AdminAcceptanceTests.Steps.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class CommonSteps : TestBase
    {
        public CommonSteps(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [StepDefinition(@"no organisation is selected")]
        public static void DoNothing()
        {
            // do nothing
        }

        public static void AssertListOfStringsIsInAscendingOrder(IEnumerable<string> stringList)
        {
            var hexList = stringList
                .Select(s => s.ToLower())
                .Select(s => Encoding.UTF8.GetBytes(s))
                .Select(h => BitConverter.ToString(h))
                .Select(r => r.Replace("-", string.Empty))
                .ToList();
            hexList.Should().BeInAscendingOrder();
        }

        [Given(@"that an Authority User has logged in on Public Browse")]
        public void GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse()
        {
            Test.Pages.Homepage.LoginLogoutLinkText("Log in");
            Test.Pages.Homepage.ClickLoginButton();
            var user = Test.AdminUser;
            Test.Pages.Authorization.EnterUsername(user.UserName);
            Test.Pages.Authorization.EnterPassword(user.PasswordHash);
            Test.Pages.Authorization.Login();
            Test.Pages.Homepage.WaitUntilLoggedInFully();
        }

        [Given(@"the Authority User is managing organisations and users")]
        public void GivenTheAuthorityUserIsManagingOrganisationsAndUsers()
        {
            GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse();
            var organisationDashboardSteps = new OrganisationDashboard.OrganisationsDashboard(Test, Context);
            organisationDashboardSteps.WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage();
            organisationDashboardSteps.ThenTheAuthorityUserIsDirectedToTheOrganisationsDashboard();
        }

        [Given(@"I am on a random organisation user account dashboard")]
        public void GivenIAmOnARandomOrganisationUserAccountDashboard()
        {
            GivenTheAuthorityUserIsManagingOrganisationsAndUsers();
            var organisationDashboardSteps = new OrganisationDashboard.OrganisationsDashboard(Test, Context);
            organisationDashboardSteps.WhenAnOrganisationIsSelected();
            organisationDashboardSteps.ThenTheUserAccountsDashboardForThatOrganisationIsDisplayed();
            var odsCode = Test.Pages.UserAccountsDashboard.GetODSCode();
            Context.Add("ODSCode", odsCode);
        }

        [When(@"a specific organisation is selected")]
        public void WhenASpecificOrganisationIsSelected()
        {
            Thread.Sleep(500);
            var organisation = (Organisation)Context["Organisation"];
            Test.Pages.OrganisationDashboard.SelectNamedOrganisation(organisation.Name);
            Test.Pages.UserAccountsDashboard.OrganisationNameMatches(organisation.Name);
        }

        [When(@"they select to view a user's details from the organisation's user accounts dashboard")]
        public void WhenTheySelectToViewAUserSUserAccountsDashboard()
        {
            GivenTheAuthorityUserIsManagingOrganisationsAndUsers();
            new OrganisationDashboard.OrganisationsDashboard(Test, Context).ThenTheAuthorityUserIsDirectedToTheOrganisationsDashboard();
            WhenASpecificOrganisationIsSelected();
            Thread.Sleep(500);
            Test.Pages.UserAccountsDashboard.ViewUserLinksDisplayed().Should().BeTrue();
            var targetUser = (User)Context["BuyingUser"];
            Test.Pages.UserAccountsDashboard.ClickUserLink(User.ConcatDisplayName(targetUser));
        }

        public void CreatedUserLogsInWithGenericTestPassword()
        {
            Test.Pages.Homepage.ClickLoginButton();
            var user = (User)Context["CreatedUser"];
            Test.Pages.Authorization.EnterUsername(user.UserName);
            Test.Pages.Authorization.EnterPassword(User.GenericTestPassword());
            Test.Pages.Authorization.Login();
            Test.Pages.Authorization.WaitForLoginPageToNotBeDisplayed();
        }
    }
}
