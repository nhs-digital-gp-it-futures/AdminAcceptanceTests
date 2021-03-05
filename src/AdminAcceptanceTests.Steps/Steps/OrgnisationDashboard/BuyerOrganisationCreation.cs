namespace AdminAcceptanceTests.Steps.Steps.OrgnisationDashboard
{
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class BuyerOrganisationCreation : TestBase
    {
        public BuyerOrganisationCreation(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"a Buyer Organisation does not already exist in the Buying Catalogue")]
        public async Task GivenABuyerOrganisationDoesNotAlreadyExistInTheBuyingCatalogue()
        {
            var organisation = await new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            await organisation.Delete(Test.ConnectionString);
            Context.Add("Organisation", organisation);
            Context.Add("CreatedOrganisation", organisation);
            Context.Add("DeletedOrganisation", organisation);
        }

        [Given(@"that a User enters an ODS code for a non-Buyer Organisation")]
        public void GivenThatAUserEntersAnODSCodeForANon_BuyerOrganisation()
        {
            var knownNonBuyerOrganisationODSCode = "RAE01";
            Organisation organisation = new()
            {
                OdsCode = knownNonBuyerOrganisationODSCode,
            };
            Context.Add("Organisation", organisation);
            Context.Add("CreatedOrganisation", organisation);
        }

        [Given(@"that the User enters a code unrecognised by ODS")]
        public void GivenThatTheUserEntersACodeUnrecognisedByODS()
        {
            var unkownOrganisationODSCode = "TEST";
            Organisation organisation = new()
            {
                OdsCode = unkownOrganisationODSCode,
            };
            Context.Add("Organisation", organisation);
            Context.Add("CreatedOrganisation", organisation);
        }

        [Given(@"a Buyer Organisation already exists in the Buying Catalogue")]
        public async Task GivenABuyerOrganisationAlreadyExistsInTheBuyingCatalogue()
        {
            var organisation = await new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            Context.Add("Organisation", organisation);
        }

        [When(@"the Organisation is being created")]
        public void WhenTheOrganisationIsBeingCreated()
        {
            WhenTheUserAttemptsToCreateTheOrganisation();
            Test.Pages.CreateBuyingOrganisation.ConfirmationPageDisplayed();
        }

        [When(@"the Organisation is searched for")]
        public void WhenTheOrganisationIsSearchedFor()
        {
            var organisation = (Organisation)Context["Organisation"];
            Test.Pages.OrganisationDashboard.ClickAddOrganisationsButton();
            Test.Pages.CreateBuyingOrganisation.SearchPageDisplayed();
            Test.Pages.CreateBuyingOrganisation.EnterODSCode(organisation.OdsCode);
            Test.Pages.CreateBuyingOrganisation.SearchOrganisation();
        }

        [When(@"the user attempts to create the Organisation")]
        public void WhenTheUserAttemptsToCreateTheOrganisation()
        {
            WhenTheOrganisationIsSearchedFor();
            Test.Pages.CreateBuyingOrganisation.SelectOrganisationPageDisplayed();
            Test.Pages.CreateBuyingOrganisation.SelectOrganisation();
            Test.Pages.CreateBuyingOrganisation.CreateOrganisationPageDisplayed();
            Test.Pages.CreateBuyingOrganisation.CreateOrganisation();
        }

        [Then(@"the Organisation exists in the Buying Catalogue")]
        public async Task ThenTheOrganisationExistsInTheBuyingCatalogue()
        {
            var organisation = (Organisation)Context["Organisation"];
            var orgInDb = await Organisation.RetrieveByODSCode(Test.ConnectionString, organisation.OdsCode);
            orgInDb.Should().NotBeNull();
        }

        [Then(@"the Primary Role ID from ODS identifies the Organisation as a Buyer Organisation")]
        public async Task ThenThePrimaryRoleIDFromODSIdentifiesTheOrganisationAsABuyerOrganisation()
        {
            var organisation = (Organisation)Context["Organisation"];
            var orgInDb = await Organisation.RetrieveByODSCode(Test.ConnectionString, organisation.OdsCode);
            orgInDb.PrimaryRoleId.Should().NotBeNull();
            orgInDb.PrimaryRoleId.Should().BeOneOf("RO98", "RO177", "RO213", "RO272");
        }

        [Then(@"a validation error message will be returned")]
        public void ThenAValidationErrorMessageWillBeReturned()
        {
            Test.Pages.CreateBuyingOrganisation.ErrorSummaryDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed the organisation already exists")]
        public void ThenTheUserIsInformedTheOrganisationAlreadyExists()
        {
            Test.Pages.CreateBuyingOrganisation.OrganisationAlreadyExistsPageDisplayed();
        }
    }
}
