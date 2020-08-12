using AdminAcceptanceTests.Steps.Utils;
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
            Test.Pages.UserAccountsDashboard.ClickEditOrganisationButton();
            Test.Pages.EditOrganisation.PageDisplayed();
        }
    }
}
