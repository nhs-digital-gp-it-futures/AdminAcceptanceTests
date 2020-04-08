using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.Authorization
{
    [Binding]
    public class PasswordReset : TestBase
    {
        public PasswordReset(UITest test, ScenarioContext context) : base(test, context)
        {

        }

        [Given(@"that a user wants to reset their password")]
        public void GivenThatAUserWantsToResetTheirPassword()
        {
            var CurrentOrganisation = new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId: CurrentOrganisation.OrganisationId);
            user.Create(Test.ConnectionString);
            Context.Add("CreatedUser", user);
        }

        [Given(@"that an unknown user wants to reset their password")]
        public void GivenThatAnUnknownUserWantsToResetTheirPassword()
        {
            User user = new User().GenerateRandomUser();
            Context.Add("CreatedUser", user);
        }

        [When(@"the User has followed the request a password reset journey and entered their e-mail address")]
        public async Task WhenTheUserHasFollowedTheRequestAPasswordResetJourneyAndEnteredTheirE_MailAddress()
        {
            Test.Pages.Homepage.ClickLoginButton();
            Test.Pages.Authorization.ClickForgotPassword();
            Test.Pages.RequestPasswordReset.EnterEmail(((User)Context["CreatedUser"]).Email);
            var precount = await EmailServerDriver.GetEmailCountAsync(Test.Url);
            Context.Add("EmailCount", precount);
            Test.Pages.RequestPasswordReset.Submit();
            Test.Pages.RequestPasswordReset.ConfirmationDisplayed().Should().BeTrue();
        }

        [Then(@"the reset url is sent to the e-mail address")]
        public async Task ThenTheResetUrlIsSentToTheE_MailAddress()
        {
            var currentCount = await EmailServerDriver.GetEmailCountAsync(Test.Url);
            var precount = (int)Context["EmailCount"];
            currentCount.Should().BeGreaterThan(precount);
            var email = (await EmailServerDriver.FindAllEmailsAsync(Test.Url)).Last();
            email.To.Should().BeEquivalentTo(((User)Context["CreatedUser"]).Email);
            Context.Add("Email", email);
        }

    }
}
