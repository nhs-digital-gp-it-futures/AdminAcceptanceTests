using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.Authorization
{
    [Binding]
    public class AcceptAgreement : TestBase
    {
        public AcceptAgreement(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that a User has not accepted the Agreement")]
        public void GivenThatAUserHasNotAcceptedTheAgreement()
        {
            var user = new User().GenerateRandomUser(PrimaryOrganisationId: new Organisation().RetrieveRandomOrganisation(Test.ConnectionString).OrganisationId);
            user.CatalogueAgreementSigned = 0;
            user.Create(Test.ConnectionString);
            Context.Add("CreatedUser", user);
        }

        [When(@"the User has logged in")]
        public void WhenTheUserHasLoggedIn()
        {
            new CommonSteps(Test, Context).CreatedUserLogsInWithGenericTestPassword();
        }

        [Then(@"the User is presented with the Agreement for using the Buying Catalogue")]
        public void ThenTheUserIsPresentedWithTheAgreementForUsingTheBuyingCatalogue()
        {
            Test.Pages.AcceptAgreement.PageDisplayed();
        }

        [Given(@"that a User is presented with the Agreement")]
        public void GivenThatAUserIsPresentedWithTheAgreement()
        {
            GivenThatAUserHasNotAcceptedTheAgreement();
            WhenTheUserHasLoggedIn();
            ThenTheUserIsPresentedWithTheAgreementForUsingTheBuyingCatalogue();
        }

        [When(@"the User indicates they will accept the Agreement")]
        public void WhenTheUserIndicatesTheyWillAcceptTheAgreement()
        {
            Test.Pages.AcceptAgreement.ClickCheckbox();
        }

        [When(@"the User chooses to continue past the Agreement")]
        public void WhenTheUserChoosesToContinuePastTheAgreement()
        {
            Test.Pages.AcceptAgreement.Submit();
        }

        [When(@"the User does not indicate that they will accept the Agreement")]
        public void WhenTheUserDoesNotIndicateThatTheyWillAcceptTheAgreement()
        {
        }

        [Then(@"the User can continue their Journey past the Agreement")]
        public void ThenTheUserCanContinueTheirJourneyPastTheAgreement()
        {
            Test.Pages.Homepage.PageDisplayed();
        }

        [Then(@"the User can not continue their Journey past the Agreement")]
        public void ThenTheUserCanNotContinueTheirJourneyPastTheAgreement()
        {
            ThenTheUserIsPresentedWithTheAgreementForUsingTheBuyingCatalogue();
        }

        [Then(@"it is recorded that the Agreement is signed by the User")]
        public void ThenItIsRecordedThatTheAgreementIsSignedByTheUser()
        {
            var user = (User)Context["CreatedUser"];
            user.Retrieve(Test.ConnectionString).CatalogueAgreementSigned.Should().Be(1);
        }

        [Then(@"there is no record that the Agreement was signed")]
        public void ThenThereIsNoRecordThatTheAgreementWasSigned()
        {
            var user = (User)Context["CreatedUser"];
            user.Retrieve(Test.ConnectionString).CatalogueAgreementSigned.Should().Be(0);
        }

        [Then(@"the User is informed why they cannot continue")]
        public void ThenTheUserIsInformedWhyTheyCannotContinue()
        {
            Test.Pages.AcceptAgreement.ErrorDisplayed().Should().BeTrue();
        }

        [Given(@"that a User has accepted the agreement")]
        public void GivenThatAUserHasAcceptedTheAgreement()
        {
            GivenThatAUserIsPresentedWithTheAgreement();
            WhenTheUserIndicatesTheyWillAcceptTheAgreement();
            WhenTheUserChoosesToContinuePastTheAgreement();
            ThenTheUserCanContinueTheirJourneyPastTheAgreement();
            var authSteps = new Authorization(Test, Context);
            authSteps.WhenTheUserLogsOut();
            authSteps.ThenTheUserIsLoggedOut();
        }

        [Then(@"the User is not presented with the agreement")]
        public void ThenTheUserIsNotPresentedWithTheAgreement()
        {
            Test.Pages.AcceptAgreement.PageNotDisplayed();
            ThenTheUserCanContinueTheirJourneyPastTheAgreement();
        }

    }
}
