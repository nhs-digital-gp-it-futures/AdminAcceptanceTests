using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void WhenTheUserHasFollowedTheRequestAPasswordResetJourneyAndEnteredTheirE_MailAddress()
        {
            Test.Pages.Homepage.ClickLoginButton();
            Test.Pages.Authorization.ClickForgotPassword();
            Test.Pages.RequestPasswordReset.EnterEmail(((User)Context["CreatedUser"]).Email);
            Test.Pages.RequestPasswordReset.Submit();
            Test.Pages.RequestPasswordReset.ConfirmationDisplayed().Should().BeTrue();
        }

    }
}
