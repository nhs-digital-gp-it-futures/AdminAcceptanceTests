namespace AdminAcceptanceTests.Steps.Steps.UserAccountsDashboard
{
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class ViewUserDetails : TestBase
    {
        public ViewUserDetails(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"that a User elects to view a buying user's details")]
        public async Task GivenThatAUserElectsToViewABuyingUserSDetails()
        {
            var targetUser = await new User().RetrieveRandomBuyerUser(Test.ConnectionString);
            var taretOrganisation = await Organisation.RetrieveById(Test.ConnectionString, targetUser.PrimaryOrganisationId);
            Context.Add("BuyingUser", targetUser);
            Context.Add("Organisation", taretOrganisation);
        }

        [Then(@"the User can view the details")]
        public void ThenTheUserCanViewTheDetails()
        {
            Test.Pages.ViewUserDetails.PageDisplayed();
        }

        [Then(@"the details include Name")]
        public void ThenTheDetailsIncludeName()
        {
            Test.Pages.ViewUserDetails.NameDisplayed().Should().BeTrue();
        }

        [Then(@"Name will be concatenation of the First Name and Last Name")]
        public void ThenNameWillBeConcatenationOfTheFirstNameAndLastName()
        {
            var nameOnScreen = Test.Pages.ViewUserDetails.GetName();
            var expectedUser = (User)Context["BuyingUser"];
            var expectedName = User.ConcatDisplayName(expectedUser);
            nameOnScreen.Should().BeEquivalentTo(expectedName);
        }

        [Then(@"the details include Contact Details")]
        public void ThenTheDetailsIncludeContactDetails()
        {
            Test.Pages.ViewUserDetails.ContactDetailsDisplayed().Should().BeTrue();
        }

        [Then(@"the details include E-mail Address")]
        public void ThenTheDetailsIncludeE_MailAddress()
        {
            Test.Pages.ViewUserDetails.EmailAddressDisplayed().Should().BeTrue();
        }

        [Then(@"the details include Organisation Name")]
        public void ThenTheDetailsIncludeOrganisationName()
        {
            Test.Pages.ViewUserDetails.OrganisationNameDisplayed().Should().BeTrue();
        }
    }
}
