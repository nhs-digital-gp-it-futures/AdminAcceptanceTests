namespace AdminAcceptanceTests.Steps.Steps.Authorization
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Actions.Utils;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class PasswordReset : TestBase
    {
        public PasswordReset(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a user wants to reset their password")]
        public async Task GivenThatAUserWantsToResetTheirPassword()
        {
            var currentOrganisation = await new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            await user.Create(Test.ConnectionString);
            Context.Add("CreatedUser", user);
        }

        [Given(@"that an unknown user wants to reset their password")]
        public void GivenThatAnUnknownUserWantsToResetTheirPassword()
        {
            var user = new User().GenerateRandomUser();
            Context.Add("CreatedUser", user);
        }

        [When(@"the User has followed the request a password reset journey and entered their e-mail address")]
        public async Task WhenTheUserHasFollowedTheRequestAPasswordResetJourneyAndEnteredTheirE_MailAddress()
        {
            Test.Pages.Homepage.ClickLoginButton();
            Test.Pages.Authorization.ClickForgotPassword();
            Test.Pages.RequestPasswordReset.EnterEmail(((User)Context["CreatedUser"]).Email);
            var precount = await EmailServerDriver.GetEmailCountAsync(Test.Url, ((User)Context["CreatedUser"]).Email);
            Context.Add("EmailCount", precount);
            Test.Pages.RequestPasswordReset.Submit();
            Test.Pages.RequestPasswordReset.ConfirmationDisplayed().Should().BeTrue();
        }

        [Then(@"the reset url is sent to the e-mail address")]
        public async Task ThenTheResetUrlIsSentToTheE_MailAddress()
        {
            var user = (User)Context["CreatedUser"];
            var currentCount = await EmailServerDriver.GetEmailCountAsync(Test.Url, user.Email);
            var precount = (int)Context["EmailCount"];
            currentCount.Should().BeGreaterThan(precount);
            var email = (await EmailServerDriver.FindAllEmailsAsync(Test.Url, user.Email)).Last();
            email.To.Should().BeEquivalentTo(user.Email);
            Context.Add("Email", email);
        }

        [Then(@"the reset url is not sent to the e-mail address")]
        public async Task ThenTheResetUrlIsNotSentToTheE_MailAddress()
        {
            var currentCount = await EmailServerDriver.GetEmailCountAsync(Test.Url, ((User)Context["CreatedUser"]).Email);
            var precount = (int)Context["EmailCount"];
            currentCount.Should().Be(precount);
        }

        [Then(@"the reset url navigates to the password reset page")]
        public void ThenTheResetUrlNavigatesToThePasswordResetPage()
        {
            var email = (Email)Context["Email"];
            var url = email.ExtractUrlFromHtmlBody();
            Test.Driver.Navigate().GoToUrl(url);
            Test.Pages.SetNewPassword.PageDisplayed().Should().BeTrue();
        }

        [Given(@"the User is resetting their password and has followed the reset url")]
        public async Task GivenTheUserIsResettingTheirPasswordAndHasFollowedTheResetUrlAsync()
        {
            await GivenThatAUserWantsToResetTheirPassword();
            await WhenTheUserHasFollowedTheRequestAPasswordResetJourneyAndEnteredTheirE_MailAddress();
            await ThenTheResetUrlIsSentToTheE_MailAddress();
            ThenTheResetUrlNavigatesToThePasswordResetPage();
        }

        [When(@"the User has entered a password that meets the password policy")]
        public void WhenTheUserHasEnteredAPasswordThatMeetsThePasswordPolicy()
        {
            var validPassword = "BuyingC@t4logue123";
            var currentUser = (User)Context["CreatedUser"];
            currentUser.PasswordHash = validPassword;
            EnterPasswordAndSubmit(validPassword);
        }

        [When(@"the User has entered a password that does not meets the password policy")]
        public void WhenTheUserHasEnteredAPasswordThatDoesNotMeetsThePasswordPolicy()
        {
            var invalidPassword = "password";
            EnterPasswordAndSubmit(invalidPassword);
        }

        public void EnterPasswordAndSubmit(string passwordValue)
        {
            Test.Pages.SetNewPassword.EnterFirstPassword(passwordValue);
            Test.Pages.SetNewPassword.EnterSecondPassword(passwordValue);
            Test.Pages.SetNewPassword.Submit();
        }

        [Then(@"the password is successfully set")]
        public void ThenThePasswordIsSuccessfullySet()
        {
            Test.Pages.SetNewPassword.ConfirmationDisplayed().Should().BeTrue();
        }

        [Then(@"the User can login with those credentials")]
        public void ThenTheUserCanLoginWithThoseCredentials()
        {
            var currentUser = (User)Context["CreatedUser"];
            Test.Pages.SetNewPassword.GoToLoginPage();
            Thread.Sleep(500);
            Test.Pages.Authorization.EnterUsername(currentUser.UserName);
            Test.Pages.Authorization.EnterPassword(currentUser.PasswordHash);
            Test.Pages.Authorization.Login();
            new Authorization(Test, Context).ThenTheUserWillBeLoggedIn();
        }

        [Then(@"the User is informed that the Password has not been set successfully")]
        public void ThenTheUserIsInformedThatThePasswordHasNotBeenSetSuccessfully()
        {
            Test.Pages.SetNewPassword.ErrorDisplayed().Should().BeTrue();
        }
    }
}
