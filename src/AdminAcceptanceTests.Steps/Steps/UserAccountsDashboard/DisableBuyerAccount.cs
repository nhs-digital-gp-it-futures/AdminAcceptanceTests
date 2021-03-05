namespace AdminAcceptanceTests.Steps.Steps.UserAccountsDashboard
{
    using System.Threading;
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class DisableBuyerAccount : TestBase
    {
        public DisableBuyerAccount(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"a buyer account is currently enabled")]
        public async Task GivenABuyerAccountIsCurrentlyEnabled()
        {
            var taretOrganisation = await new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            var buyerUser = new User().GenerateRandomUser(primaryOrganisationId: taretOrganisation.OrganisationId);
            buyerUser.Disabled = 0;
            await buyerUser.Create(Test.ConnectionString);

            Context.Add("Organisation", taretOrganisation);
            Context.Add("BuyingUser", buyerUser);
            Context.Add("CreatedUser", buyerUser);
        }

        [Given(@"a buyer account is currently disabled")]
        public async Task GivenABuyerAccountIsCurrentlyDisabled()
        {
            var targetOrganisation = await new Organisation().RetrieveRandomOrganisation(Test.ConnectionString);
            var buyerUser = new User().GenerateRandomUser(primaryOrganisationId: targetOrganisation.OrganisationId);
            buyerUser.Disabled = 1;
            await buyerUser.Create(Test.ConnectionString);

            Context.Add("Organisation", targetOrganisation);
            Context.Add("BuyingUser", buyerUser);
            Context.Add("CreatedUser", buyerUser);
        }

        [When(@"the authority user disables the buyer account")]
        [When(@"the authority user enables the buyer account")]
        public void WhenTheAuthorityUserDisablesTheBuyerAccount()
        {
            new CommonSteps(Test, Context).WhenTheySelectToViewAUserSUserAccountsDashboard();
            Thread.Sleep(500);
            Test.Pages.ViewUserDetails.PageDisplayed();
            Test.Pages.ViewUserDetails.DisableAccount();

            // go back to the user account dashboard
            Test.Driver.Navigate().Back();
            Test.Pages.ViewUserDetails.PageDisplayed();
            Test.Driver.Navigate().Back();
            Test.Driver.Navigate().Refresh();
            Test.Pages.UserAccountsDashboard.OrganisationNameMatches(((Organisation)Context["Organisation"]).Name);
        }

        [Then(@"the account listed on the user accounts dashboard shows as disabled")]
        public void ThenTheAccountListedOnTheUserAccountsDashboardShowsAsDisabled()
        {
            var user = (User)Context["BuyingUser"];
            var username = User.ConcatDisplayName(user);
            Test.Pages.UserAccountsDashboard.ExpectedUserHasDisabledFlag(username).Should().BeTrue();
        }

        [Then(@"the account listed on the user accounts dashboard does not show as disabled")]
        public void ThenTheAccountListedOnTheUserAccountsDashboardDoesNotShowAsDisabled()
        {
            var user = (User)Context["BuyingUser"];
            var username = User.ConcatDisplayName(user);
            Test.Pages.UserAccountsDashboard.ExpectedUserHasDisabledFlag(username).Should().BeFalse();
        }

        [Then(@"the buyer user cannot login")]
        public void ThenTheBuyerUserCannotLogin()
        {
            Test.Pages.Homepage.LogOut();
            Test.Pages.Homepage.WaitUntilLoggedOutFully();
            Test.Pages.Homepage.LoginLogoutLinkText("Log In");
            Test.Pages.Homepage.ClickLoginButton();
            var user = (User)Context["BuyingUser"];
            Test.Pages.Authorization.EnterUsername(user.UserName);
            Test.Pages.Authorization.EnterPassword(User.GenericTestPassword());
            Test.Pages.Authorization.Login();
            Test.Pages.Authorization.WaitForErrorSummaryToBeDisplayed();
        }

        [Then(@"the buyer user can login")]
        public void ThenTheBuyerUserCanLogin()
        {
            Test.Pages.Homepage.LogOut();
            Test.Pages.Homepage.WaitUntilLoggedOutFully();
            Test.Pages.Homepage.LoginLogoutLinkText("Log In");
            Test.Pages.Homepage.ClickLoginButton();
            var user = (User)Context["BuyingUser"];
            Test.Pages.Authorization.EnterUsername(user.UserName);
            Test.Pages.Authorization.EnterPassword(User.GenericTestPassword());
            Test.Pages.Authorization.Login();
            Test.Pages.Homepage.LoginLogoutLinkText("Log out");
        }
    }
}
