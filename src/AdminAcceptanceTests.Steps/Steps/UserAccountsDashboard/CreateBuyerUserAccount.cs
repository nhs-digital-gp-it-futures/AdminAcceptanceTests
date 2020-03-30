using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
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
            BuyingUser user = new BuyingUser().GenerateRandomUser((string)Context["ODSCode"]);
            Context.Add("BuyingUser", user);
        }

        [Given(@"that mandatory data '(.*)' has not been added")]
        public void GivenThatMandatoryDataHasNotBeenAdded(string MissingField)
        {
            BuyingUser user = new BuyingUser().GenerateRandomUser((string)Context["ODSCode"]);

            switch (MissingField.ToLower())
            {
                case "first name":
                    user.FirstName = "";
                    break;
                case "last name":
                    user.LastName = "";
                    break;
                case "e-mail address":
                    user.EmailAddress = "";
                    break;
                default:
                    throw new NotImplementedException(String.Format("The parameter '%s' is not recognised", MissingField));
            }
            Context.Add("BuyingUser", user);
        }

        [Given(@"the e-mail address is not unique")]
        public void GivenTheE_MailAddressIsNotUnique()
        {
            BuyingUser user = new BuyingUser().GenerateRandomUser((string)Context["ODSCode"]);
            user.EmailAddress = "alicesmith@email.com";
            Context.Add("BuyingUser", user);
        }


    }
}
