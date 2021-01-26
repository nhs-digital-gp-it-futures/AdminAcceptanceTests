namespace AdminAcceptanceTests.Steps.Steps.OrganisationDashboard
{
    using AdminAcceptanceTests.Steps.Utils;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class OrganisationsDashboard : TestBase
    {
        public OrganisationsDashboard(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [StepDefinition(@"an Authority User clicks the admin tile on the Public Browse homepage")]
        public void WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage()
        {
            Test.Pages.Homepage.ClickAdminTile();
        }

        [Then(@"there is an additional tile for the Authority User to access the dashboard")]
        public void ThenThereIsAnAdditionalTileForTheAuthorityUserToAccessTheDashboard()
        {
            Test.Pages.Homepage.AdminTileIsDisplayed().Should().BeTrue();
        }

        [Then(@"the Authority User is directed to the Organisations Dashboard")]
        public void ThenTheAuthorityUserIsDirectedToTheOrganisationsDashboard()
        {
            Test.Pages.OrganisationDashboard.PageDisplayed();
        }

        [Then(@"the User can add an Organisation")]
        public void ThenTheUserCanAddAnOrganisation()
        {
            Test.Pages.OrganisationDashboard.AddOrganisationsButtonIsDisplayed().Should().BeTrue();
        }

        [Then(@"the User can select an Organisation")]
        public void ThenTheUserCanSelectAnOrganisation()
        {
            Test.Pages.OrganisationDashboard.LinksToManageOrganisationsAreDisplayed().Should().BeTrue();
        }

        [When(@"an organisation is selected")]
        public void WhenAnOrganisationIsSelected()
        {
            Context.Add("Organisation", Test.Pages.OrganisationDashboard.SelectOrganisation());
        }

        [Then(@"the User Accounts Dashboard for that organisation is displayed")]
        public void ThenTheUserAccountsDashboardForThatOrganisationIsDisplayed()
        {
            Test.Pages.UserAccountsDashboard.OrganisationNameMatches((string)Context["Organisation"]);
        }
    }
}
