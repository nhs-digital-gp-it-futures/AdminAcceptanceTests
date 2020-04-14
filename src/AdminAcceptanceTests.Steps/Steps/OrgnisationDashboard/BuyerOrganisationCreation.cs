using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
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
            var KnownBuyerOrganisationODSCode = "42D";
            var Organisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, KnownBuyerOrganisationODSCode);
            Organisation.Delete(Test.ConnectionString);
            Context.Add("Organisation", Organisation);
            Context.Add("DeletedOrganisation", Organisation);
        }
        
        [Given(@"that a User enters an ODS code for a non-Buyer Organisation")]
        public void GivenThatAUserEntersAnODSCodeForANon_BuyerOrganisation()
        {
            var KnownNonBuyerOrganisationODSCode = "RAE01";
            var Organisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, KnownNonBuyerOrganisationODSCode);
            Organisation.Delete(Test.ConnectionString);
            Context.Add("Organisation", Organisation);
        }
        
        [Given(@"that the User enters a code unrecognised by ODS")]
        public void GivenThatTheUserEntersACodeUnrecognisedByODS()
        {
            var UnkownOrganisationODSCode = "TEST";
            Organisation Organisation = new Organisation();
            Organisation.OdsCode = UnkownOrganisationODSCode;
            Context.Add("Organisation", Organisation);
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
            var Organisation = (Organisation)Context["Organisation"];
            Context.Pending();
        }
        
        [When(@"the Organisation is searched for")]
        public void WhenTheOrganisationIsSearchedFor()
        {
            var Organisation = (Organisation)Context["Organisation"];
            Context.Pending();
        }
        
        [Then(@"the Organisation exists in the Buying Catalogue")]
        public void ThenTheOrganisationExistsInTheBuyingCatalogue()
        {
            var Organisation = (Organisation)Context["Organisation"];
            Context.Pending();
        }
        
        [Then(@"the Primary Role ID from ODS identifies the Organisation as a Buyer Organisation")]
        public void ThenThePrimaryRoleIDFromODSIdentifiesTheOrganisationAsABuyerOrganisation()
        {
            var Organisation = (Organisation)Context["Organisation"];
            Context.Pending();
        }
        
        [Then(@"a validation error message will be returned")]
        public void ThenAValidationErrorMessageWillBeReturned()
        {
            Context.Pending();
        }
    }
}
