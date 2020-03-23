using AdminAcceptanceTests.Steps.Utils;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.OrgnisationDashboard
{
    [Binding]
    public class OrganisationsDashboard : TestBase
    {
        public OrganisationsDashboard(UITest test, ScenarioContext context) : base(test, context)
        {

        }
        
        [When(@"an Authority User clicks the admin tile on the Public Browse homepage")]
        public void WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage()
        {
            _test.Pages.Homepage.ClickAdminTile();
        }
        
        [Then(@"there is an additional tile for the Authority User to access the dashboard")]
        public void ThenThereIsAnAdditionalTileForTheAuthorityUserToAccessTheDashboard()
        {
            _test.Pages.Homepage.AdminTileIsDisplayed().Should().BeTrue();
        }
        
        [Then(@"the Authority User is directed to the Organisations Dashboard")]
        public void ThenTheAuthorityUserIsDirectedToTheOrganisationsDashboard()
        {
            _test.Pages.OrganisationDashboard.PageDisplayed();
        }
        
        [Then(@"the User can add an Organisation")]
        public void ThenTheUserCanAddAnOrganisation()
        {
            _test.Pages.OrganisationDashboard.AddOrganisationsButtonIsDisplayed().Should().BeTrue();
        }
        
        [Then(@"the User can select an Organisation")]
        public void ThenTheUserCanSelectAnOrganisation()
        {
            _test.Pages.OrganisationDashboard.LinksToManageOrganisationsAreDisplayed().Should().BeTrue();
        }
    }
}
