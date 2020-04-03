using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.OrgnisationDashboard
{
    [Binding]
    public class EditOrganisation : TestBase
    {
        public EditOrganisation(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that an authority user is editing an organisation's account details")]
        public void GivenThatAnAuthorityUserIsEditingAnOrganisationSAccountDetails()
        {
            new CommonSteps(Test, Context).GivenIAmOnARandomOrganisationUserAccountDashboard();
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, (string)Context["ODSCode"]);
            Context.Add("OldCatalogueAgreementSignedValue", CurrentOrganisation.CatalogueAgreementSigned);
            Test.Pages.UserAccountsDashboard.ClickEditOrganisationButton();
            Test.Pages.EditOrganisation.PageDisplayed();
        }

        [When(@"an authority user edits the end user agreement")]
        public void WhenAnAuthorityUserEditsTheEndUserAgreement()
        {
            Test.Pages.EditOrganisation.ClickCatalogueAgreementCheckbox();
            Test.Pages.EditOrganisation.Save();
            Test.Pages.EditOrganisation.ConfirmationPageDisplayed().Should().BeTrue();
        }

        [Then(@"the organisation's end user agreement status is updated")]
        public void ThenTheOrganisationSEndUserAgreementStatusIsUpdated()
        {
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, (string)Context["ODSCode"]);
            var OldValue = (int)Context["OldCatalogueAgreementSignedValue"];
            CurrentOrganisation.CatalogueAgreementSigned.Should().NotBe(OldValue);
        }

        [Then(@"an authority user resets the end user agreement")]
        public void ThenAnAuthorityUserResetsTheEndUserAgreement()
        {
            Test.Driver.Navigate().Back();
            WhenAnAuthorityUserEditsTheEndUserAgreement();
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, (string)Context["ODSCode"]);
            var OldValue = (int)Context["OldCatalogueAgreementSignedValue"];
            CurrentOrganisation.CatalogueAgreementSigned.Should().Be(OldValue);
        }

    }
}
