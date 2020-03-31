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
    public class CreateBuyerUserAccount : TestBase
    {
        public CreateBuyerUserAccount(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"I am on a random organisation user account dashboard")]
        public void GivenIAmOnARandomOrganisationUserAccountDashboard()
        {
            new CommonSteps(Test, Context).GivenThatAnAuthorityUserHasLoggedInOnPublicBrowse();
            var OrganisationDashboardSteps = new OrganisationDashboard.OrganisationsDashboard(Test, Context);
            OrganisationDashboardSteps.WhenAnAuthorityUserClicksTheAdminTileOnThePublicBrowseHomepage();
            OrganisationDashboardSteps.WhenAnOrganisationIsSelected();
            OrganisationDashboardSteps.ThenTheUserAccountsDashboardForThatOrganisationIsDisplayed();
            String ODSCode = Test.Pages.UserAccountsDashboard.GetODSCode();
            Context.Add("ODSCode", ODSCode);
        }

        [Given(@"account details have been provided")]
        public void GivenAccountDetailsHaveBeenProvided()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(true, CurrentOrganisation.Id);
            Context.Add("BuyingUser", user);
        }

        [Given(@"that mandatory data '(.*)' has not been added")]
        public void GivenThatMandatoryDataHasNotBeenAdded(string MissingField)
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(true, CurrentOrganisation.Id);

            switch (MissingField.ToLower())
            {
                case "first name":
                    user.FirstName = "";
                    break;
                case "last name":
                    user.LastName = "";
                    break;
                case "e-mail address":
                    user.Email = "";
                    break;
                default:
                    throw new NotImplementedException(String.Format("The parameter '%s' is not recognised", MissingField));
            }
            Context.Add("BuyingUser", user);
        }

        [Given(@"the e-mail address is not unique")]
        public void GivenTheE_MailAddressIsNotUnique()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(true, CurrentOrganisation.Id);
            user.Email = "alicesmith@email.com";
            Context.Add("BuyingUser", user);
        }

        [When(@"I create the buying user account")]
        public void WhenICreateTheBuyingUserAccount()
        {
            //CompleteAndSubmitForm();
            //wait for confirmation page => data-test-id="add-user-confirmation"
        }

        [When(@"the user attempts to add the buying user")]
        public void WhenIAttemptToCreateTheBuyingUserAccount()
        {
            CompleteAndSubmitForm();
            //Test.Pages.CreateBuyerUser.ErrorSummaryDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that the e-mail address it not unique")]
        public void ThenTheUserIsInformedThatTheE_MailAddressItNotUnique()
        {
            Test.Pages.CreateBuyerUser.EmailAlreadyExistsErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that mandatory data 'First Name' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataFirstNameIsMissing()
        {
            Test.Pages.CreateBuyerUser.FirstNameRequiredErrorDisplayed().Should().BeTrue(); ;
        }

        [Then(@"the user is informed that mandatory data 'Last Name' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataLastNameIsMissing()
        {
            Test.Pages.CreateBuyerUser.LastNameRequiredErrorDisplayed().Should().BeTrue(); ;
        }

        [Then(@"the user is informed that mandatory data 'E-mail Address' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataEmaiAddressIsMissing()
        {
            Test.Pages.CreateBuyerUser.EmailAlreadyRequiredErrorDisplayed().Should().BeTrue(); ;
        }

        [Then(@"the account will be associated with an organisation")]
        public void ThenTheAccountWillBeAssociatedWithAnOrganisation()
        {
            var enteredUser = (User)Context["BuyingUser"];
            enteredUser.Email = "BobSmith@email.com";
            var retrievedUser = enteredUser.Retrieve(Test.ConnectionString);
        }

        private void CompleteAndSubmitForm()
        {
            Test.Pages.UserAccountsDashboard.ClickAddUserButton();
            Test.Pages.CreateBuyerUser.PageDisplayed().Should().BeTrue();
            Test.Pages.CreateBuyerUser.CompleteForm((User)Context["BuyingUser"]);
            Test.Pages.CreateBuyerUser.SubmitUserDetails();
        }
    }
}
