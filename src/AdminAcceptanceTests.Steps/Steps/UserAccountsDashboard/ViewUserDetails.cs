using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.UserAccountsDashboard
{
    [Binding]
    public class ViewUserDetails : TestBase
    {
        public ViewUserDetails(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that a User elects to view a buying user's details")]
        public void GivenThatAUserElectsToViewABuyingUserSDetails()
        {
            var targetUser = new User().RetrieveRandomBuyerUser(Test.ConnectionString);
            var taretOrganisation = new Organisation().RetrieveById(Test.ConnectionString, targetUser.PrimaryOrganisationId);
            Context.Add("BuyingUser", targetUser);
            Context.Add("Organisation", taretOrganisation);
        }

        [When(@"they select to view a user's details from the organisation's user accounts dashboard")]
        public void WhenTheySelectToViewAUserSUserAccountsDashboard()
        {
            new CommonSteps(Test, Context).GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse();
            var OrganisationDashboardSteps = new OrganisationDashboard.OrganisationsDashboard(Test, Context);
            OrganisationDashboardSteps.WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage();
            OrganisationDashboardSteps.ThenTheAuthorityUserIsDirectedToTheOrganisationsDashboard();
            OrganisationDashboardSteps.WhenASpecificOrganisationIsSelected();
            Test.Pages.UserAccountsDashboard.ViewUserLinksDisplayed().Should().BeTrue();
            var targetUser = (User)Context["BuyingUser"];
            Test.Pages.UserAccountsDashboard.ClickUserLink(string.Join(" ", targetUser.FirstName, targetUser.LastName));
        }

        [Then(@"the User can view the details")]
        public void ThenTheUserCanViewTheDetails()
        {
            Test.Pages.ViewUserDetails.PageDisplayed();
        }

        [Then(@"the details include Name")]
        public void ThenTheDetailsIncludeName()
        {
            Test.Pages.ViewUserDetails.NameDisplayed().Should().BeTrue();
        }

        [Then(@"Name will be concatenation of the First Name and Last Name")]
        public void ThenNameWillBeConcatenationOfTheFirstNameAndLastName()
        {
            var nameOnScreen = Test.Pages.ViewUserDetails.GetName();
            var expectedUser = (User)Context["BuyingUser"];
            var expectedName = string.Join(" ", expectedUser.FirstName, expectedUser.LastName);
            nameOnScreen.Should().BeEquivalentTo(expectedName);
        }

        [Then(@"the details include Contact Details")]
        public void ThenTheDetailsIncludeContactDetails()
        {
            Test.Pages.ViewUserDetails.ContactDetailsDisplayed().Should().BeTrue();
        }

        [Then(@"the details include E-mail Address")]
        public void ThenTheDetailsIncludeE_MailAddress()
        {
            Test.Pages.ViewUserDetails.EmailAddressDisplayed().Should().BeTrue();
        }

        [Then(@"the details include Organisation Name")]
        public void ThenTheDetailsIncludeOrganisationName()
        {
            Test.Pages.ViewUserDetails.OrganisationNameDisplayed().Should().BeTrue();
        }

    }
}
