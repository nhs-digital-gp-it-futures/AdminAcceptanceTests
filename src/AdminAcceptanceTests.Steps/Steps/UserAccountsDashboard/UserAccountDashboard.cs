namespace AdminAcceptanceTests.Steps.Steps.UserAccountsDashboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class UserAccountDashboard : TestBase
    {
        public UserAccountDashboard(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Then(@"there is a button the to edit the Organisation's Account details")]
        public void ThenThereIsAButtonTheToEditTheOrganisationsAccountDetails()
        {
            Test.Pages.UserAccountsDashboard.EditOrganisationButtonDisplayed().Should().BeTrue();
        }

        [Then(@"there is a button to start off the Create User Account journey")]
        public void ThenThereIsAButtonToStartOffTheCreateUserAccountJourney()
        {
            Test.Pages.UserAccountsDashboard.AddUserButtonDisplayed().Should().BeTrue();
        }

        [Then(@"there is a link to edit the User's Account details")]
        public void ThenThereIsALinkToEditTheUsersAccountDetails()
        {
            Test.Pages.UserAccountsDashboard.ViewUserLinksDisplayed().Should().BeTrue();
        }

        [Then(@"the related ODS code is presented")]
        public async Task ThenTheRelatedOrganisationOdsCodesAreDisplayedAsync()
        {
            var currentOrgCode = Test.Driver.Url.Split('/').Last();
            var relatedOrgs = await RelatedOrganisations.GetRelatedOrganisations(Test.ConnectionString, new Guid(currentOrgCode));
            List<string> odsCodes = new();

            foreach (var org in relatedOrgs)
            {
                odsCodes.Add((await Organisation.RetrieveById(Test.ConnectionString, org.RelatedOrganisationId)).OdsCode);
            }

            Test.Pages.UserAccountsDashboard.GetRelatedODSCodes().Should().BeEquivalentTo(odsCodes);
        }

        [Then(@"the user can see a list of all available organisations in the Buying Catalogue")]
        public async Task ThenTheUserCanSeeAListOfAllAvailableOrganisationsInTheBuyingCatalogueAsync()
        {
            var selectedOrg = Test.Driver.Url.Split('/').Last();

            var expectedOrg = await RelatedOrganisations.GetRelatedOrganisations(Test.ConnectionString, new Guid(selectedOrg));

            List<string> orgNames = new();

            foreach (var org in expectedOrg)
            {
                orgNames.Add((await Organisation.RetrieveById(Test.ConnectionString, org.RelatedOrganisationId)).OdsCode);
            }

            Test.Pages.UserAccountsDashboard.GetRelatedODSCodes().Should().BeEquivalentTo(orgNames);
        }

        [Then(@"there is a control to add a new related organisation")]
        public void ThenThereIsAControlToAddANewRelatedOrganisation()
        {
            Test.Pages.UserAccountsDashboard.AddAnOrganisationButtonDisplayed();
        }

        [Then(@"the list of organisations is presented in alphabetical order")]
        public void ThenTheListOfOrganisationsIsPresentedInAlphabeticalOrder()
        {
           CommonSteps.AssertListOfStringsIsInAscendingOrder(Test.Pages.UserAccountsDashboard.GetRadioButtonText());
        }

        [Then(@"user can select an Organisation")]
        public void ThenUserCanSelectAnOrganisation()
        {
            Test.Pages.UserAccountsDashboard.RemoveButtonDisplayed().Should().BeTrue();
        }

        [Given(@"that the user is on the user account dashboard")]
        public void GivenThatTheUserIsOnTheSelectAnOrganisationPage()
        {
            Test.Pages.Homepage.ClickAdminTile();
            Context.Add("Organisation", Test.Pages.OrganisationDashboard.SelectOrganisation());
            Test.Pages.UserAccountsDashboard.ClickAddAnOrganisationButton();
            Test.Pages.UserAccountsDashboard.AddOrganisationPageDisplayed().Should().BeTrue();
        }

        [Given(@"there is a control to confirm")]
        public void GivenThereIsAControlToConfirm()
        {
            Test.Pages.UserAccountsDashboard.ConfirmButtonDisplayed().Should().BeTrue();
        }

        [When(@"the user chooses to confirm")]
        public void WhenTheUserChoosesToConfirmWithoutSelectingAnOrganisation()
        {
            Test.Pages.UserAccountsDashboard.ClickConfirmButton();
        }

        [Then(@"the user is presented with an error message")]
        public void ThenTheUserIsPresentedWithAnErrorMessage()
        {
            Test.Pages.UserAccountsDashboard.ErrorSummaryDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed they have to select an organisation")]
        public void ThenTheUserIsInformedTheyHaveToSelectAnOrganisation()
        {
            Test.Pages.UserAccountsDashboard.ErrorMessagesDisplayed().Should().BeTrue();
        }

        [When(@"the user chooses to go back")]
        public void WhenTheUserChoosesToGoBack()
        {
            Test.Pages.UserAccountsDashboard.ClickBackLink();
        }

        [Then(@"the organisation's information page is presented")]
        [StepDefinition(@"the user chooses to confirm a new related organisation")]
        [Then(@"the user is taken back to the Organisation's information page")]
        public void ThenTheUserIsTakenBackToTheOrganisationSInformationPage()
        {
            Test.Pages.UserAccountsDashboard.AddOrganisationPageDisplayed().Should().BeTrue();
        }

        [Given(@"that the user is on the organisation's information page")]
        public void GivenThatTheUserIsOnTheOrganisationSInformationPage()
        {
            Test.Pages.Homepage.ClickAdminTile();
            Context.Add("Organisation", Test.Pages.OrganisationDashboard.SelectOrganisation());
        }

        [When(@"the user selects an organisation")]
        public void WhenTheUserSelectsAnOrganisation()
        {
            Test.Pages.UserAccountsDashboard.ClickRadioButton();
            Test.Pages.UserAccountsDashboard.ClickConfirmButton();
        }

        [Then(@"the user is presented with a confirmation page")]
        public void ThenTheUserIsPresentedWithAConfirmationPage()
        {
            Test.Pages.UserAccountsDashboard.NamedPageTitleDisplayed("Remove organisation");
        }

        [Given(@"that the user wants to manage the proxy relationship")]
        public void ThatTheUserWantsToManageTheProxRelationship()
        {
            Test.Pages.Homepage.ClickAdminTile();
            Context.Add("Organisation", Test.Pages.OrganisationDashboard.SelectOrganisation());
        }

        [StepDefinition(@"there is a control to remove the organisation")]
        [Given(@"there is a control to remove the organisation")]
        public void GivenTheRemoveOrganisationInformationPageIsPresented()
        {
            Test.Pages.UserAccountsDashboard.RemoveLinkDisplayed();
        }

        [When(@"the user clicks the remove link")]
        public void WhenTheUserClicksTheRemoveLink()
        {
            Test.Pages.UserAccountsDashboard.ClickRemoveLink();
        }

        [Given(@"the user is on the confirmation page,")]
        public void GivenTheUserIsOnTheConfirmationPage()
        {
            Test.Pages.Homepage.ClickAdminTile();
            Context.Add("Organisation", Test.Pages.OrganisationDashboard.SelectOrganisation());
            Test.Pages.UserAccountsDashboard.ClickAddAnOrganisationButton();
            Test.Pages.UserAccountsDashboard.ClickRadioButton();
            Test.Pages.UserAccountsDashboard.ClickConfirmButton();
            Test.Pages.UserAccountsDashboard.ClickRemoveLink();
            Test.Pages.UserAccountsDashboard.NamedPageTitleDisplayed("Remove organisation");
        }


        [Then(@"the user can select one organisation")]
        public void ThenTheUserCanSelectOneOrganisation()
        {
            Test.Pages.OrganisationDashboard.LinksToManageOrganisationsAreDisplayed();
        }

        [StepDefinition(@"the remove organisation information page is presented")]
        
        public void ThenTheOrganisationSInformationPageIsPresented()
        {
            Test.Pages.EditOrganisation.PageDisplayed();
        }

        [Then(@"the organisation is included in the related organisation section on the Organisation's information page")]
        public void ThenTheOrganisationIsIncludedInTheRelatedOrganisationSectionOnTheOrganisationSInformationPage()
        {
            Test.Pages.UserAccountsDashboard.OrgNameAndODSCodeIsDisplayed();
        }

        [Then(@"there is a Remove Organisation Button")]
        public void ThenThereIsARemoveOrganisationButton()
        {
            Test.Pages.UserAccountsDashboard.RemoveButtonDisplayed();
        }

        [Then(@"the related organisation is removed from the Organisation's information page")]
        public void ThenTheRelatedOrganisationIsRemovedFromTheOrganisationSInformationPage()
        {
            Test.Pages.UserAccountsDashboard.RelatedNameAndOdsDisplayed().Should().BeFalse();
        }

        [When(@"the user chooses to cancel")]
        public void WhenTheUserChoosesToCancel()
        {
         Test.Pages.UserAccountsDashboard.ClickRemoveLink();
        }
    }
}
