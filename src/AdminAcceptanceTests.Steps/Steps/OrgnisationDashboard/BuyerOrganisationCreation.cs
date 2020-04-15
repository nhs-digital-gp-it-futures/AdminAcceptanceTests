using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.OrgnisationDashboard
{
    [Binding]
    public class BuyerOrganisationCreation : TestBase
    {
        public BuyerOrganisationCreation(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"a Buyer Organisation does not already exist in the Buying Catalogue")]
        public void GivenABuyerOrganisationDoesNotAlreadyExistInTheBuyingCatalogue()
        {            
            var Organisation = new Organisation().RetrieveRandomOrganisationWithNoUsers(Test.ConnectionString);
            Organisation.Delete(Test.ConnectionString);
            Context.Add("Organisation", Organisation);
            Context.Add("CreatedOrganisation", Organisation);
            Context.Add("DeletedOrganisation", Organisation);
        }
        
        [Given(@"that a User enters an ODS code for a non-Buyer Organisation")]
        public void GivenThatAUserEntersAnODSCodeForANon_BuyerOrganisation()
        {
            var KnownNonBuyerOrganisationODSCode = "RAE01";
            var Organisation = new Organisation();
            Organisation.OdsCode = KnownNonBuyerOrganisationODSCode;
            Context.Add("Organisation", Organisation);
            Context.Add("CreatedOrganisation", Organisation);
        }
        
        [Given(@"that the User enters a code unrecognised by ODS")]
        public void GivenThatTheUserEntersACodeUnrecognisedByODS()
        {
            var UnkownOrganisationODSCode = "TEST";
            Organisation Organisation = new Organisation();
            Organisation.OdsCode = UnkownOrganisationODSCode;
            Context.Add("Organisation", Organisation);
            Context.Add("CreatedOrganisation", Organisation);
        }
        
        [Given(@"a Buyer Organisation already exists in the Buying Catalogue")]
        public void GivenABuyerOrganisationAlreadyExistsInTheBuyingCatalogue()
        {
            var Organisation = new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            Context.Add("Organisation", Organisation);
        }
        
        [When(@"the Organisation is being created")]
        public void WhenTheOrganisationIsBeingCreated()
        {
            WhenTheOrganisationIsSearchedFor();
            Test.Pages.CreateBuyingOrganisation.SelectOrganisationPageDisaplyed();
            Test.Pages.CreateBuyingOrganisation.SelectOrganisation();
            Test.Pages.CreateBuyingOrganisation.CreateOrganisationPageDisplayed();
            Test.Pages.CreateBuyingOrganisation.CreateOrganisation();
            Test.Pages.CreateBuyingOrganisation.ConfirmationPageDisplayed();
        }
        
        [When(@"the Organisation is searched for")]
        public void WhenTheOrganisationIsSearchedFor()
        {
            var Organisation = (Organisation)Context["Organisation"];
            Test.Pages.OrganisationDashboard.ClickAddOrganisationsButton();
            Test.Pages.CreateBuyingOrganisation.SearchPageDisplayed();
            Test.Pages.CreateBuyingOrganisation.EnterODSCode(Organisation.OdsCode);
            Test.Pages.CreateBuyingOrganisation.SearchOrganisation();
        }
        
        [Then(@"the Organisation exists in the Buying Catalogue")]
        public void ThenTheOrganisationExistsInTheBuyingCatalogue()
        {
            var Organisation = (Organisation)Context["Organisation"];
            var OrgInDb = Organisation.RetrieveByODSCode(Test.ConnectionString, Organisation.OdsCode);
            OrgInDb.Should().NotBeNull();
        }
        
        [Then(@"the Primary Role ID from ODS identifies the Organisation as a Buyer Organisation")]
        public void ThenThePrimaryRoleIDFromODSIdentifiesTheOrganisationAsABuyerOrganisation()
        {
            var Organisation = (Organisation)Context["Organisation"];
            var OrgInDb = Organisation.RetrieveByODSCode(Test.ConnectionString, Organisation.OdsCode);
            OrgInDb.PrimaryRoleId.Should().NotBeNull();
            OrgInDb.PrimaryRoleId.Should().BeOneOf("RO98", "RO177");
        }
        
        [Then(@"a validation error message will be returned")]
        public void ThenAValidationErrorMessageWillBeReturned()
        {
            Test.Pages.CreateBuyingOrganisation.ErrorSummaryDisplayed().Should().BeTrue();
        }
    }
}
