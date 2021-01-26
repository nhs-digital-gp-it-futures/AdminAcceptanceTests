namespace AdminAcceptanceTests.Steps.Steps.Authorization
{
    using AdminAcceptanceTests.Steps.Utils;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class Registration : TestBase
    {
        public Registration(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [When(@"the User clicks the request an account link on the login page")]
        public void WhenTheUserClicksTheRequestAnAccountLinkOnTheLoginPage()
        {
            Test.Pages.Authorization.ClickRequestAnAccountLink();
        }

        [Then(@"a link to request an account is displayed")]
        public void ThenALinkToRequestAnAccountIsDisplayed()
        {
            Test.Pages.Authorization.RequestAnAccountLinkIsDisplayed().Should().BeTrue();
        }

        [Then(@"the request an account page is displayed")]
        public void ThenTheRequestAnAccountPageIsDisplayed()
        {
            Test.Pages.RequestAnAccount.PageDisplayed().Should().BeTrue();
        }

        [Then(@"the request an account button has the expected mailto")]
        public void ThenTheRequestAnAccountButtonHasTheExpectedMailto()
        {
            Test.Pages.RequestAnAccount.GetRequestAnAccountButtonMailToValue().Should().ContainEquivalentOf("mailto:buying.catalogue@nhs.net");
        }
    }
}
