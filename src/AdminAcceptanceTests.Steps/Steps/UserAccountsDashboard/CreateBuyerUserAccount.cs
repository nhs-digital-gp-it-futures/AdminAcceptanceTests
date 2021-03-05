namespace AdminAcceptanceTests.Steps.Steps.UserAccountsDashboard
{
    using System;
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using Bogus;
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class CreateBuyerUserAccount : TestBase
    {
        public CreateBuyerUserAccount(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [Given(@"account details have been provided")]
        public async Task GivenAccountDetailsHaveBeenProvided()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            Context.Add("BuyingUser", user);
            Context.Add("OrganisationId", currentOrganisation.OrganisationId);
        }

        [Given(@"that mandatory data '(.*)' has not been added")]
        public async Task GivenThatMandatoryDataHasNotBeenAdded(string missingField)
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);

            switch (missingField.ToLower())
            {
                case "first name":
                    user.FirstName = string.Empty;
                    break;
                case "last name":
                    user.LastName = string.Empty;
                    break;
                case "e-mail address":
                    user.Email = string.Empty;
                    break;
                case "phone number":
                    user.PhoneNumber = string.Empty;
                    break;
                default:
                    throw new NotSupportedException($"The parameter '{missingField}' is not recognised");
            }

            Context.Add("BuyingUser", user);
        }

        [Given(@"the e-mail address is not unique")]
        public async Task GivenTheE_MailAddressIsNotUnique()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            user.Email = "alicesmith@email.com";
            Context.Add("BuyingUser", user);
        }

        [When(@"I create the buying user account")]
        public void WhenICreateTheBuyingUserAccount()
        {
            CompleteAndSubmitForm();
        }

        [When(@"the user attempts to add the buying user")]
        public void WhenIAttemptToCreateTheBuyingUserAccount()
        {
            CompleteAndSubmitForm();
            Test.Pages.CreateBuyerUser.ErrorSummaryDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that the e-mail address it not unique")]
        public void ThenTheUserIsInformedThatTheE_MailAddressItNotUnique()
        {
            Test.Pages.CreateBuyerUser.EmailAlreadyExistsErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that mandatory data 'First Name' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataFirstNameIsMissing()
        {
            Test.Pages.CreateBuyerUser.FirstNameRequiredErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that mandatory data 'Last Name' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataLastNameIsMissing()
        {
            Test.Pages.CreateBuyerUser.LastNameRequiredErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that mandatory data 'E-mail Address' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataEmaiAddressIsMissing()
        {
            Test.Pages.CreateBuyerUser.EmailRequiredErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that mandatory data 'Phone Number' is missing")]
        public void ThenTheUserIsInformedThatMandatoryDataPhoneNumberIsMissing()
        {
            Test.Pages.CreateBuyerUser.PhoneNumberRequiredErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the account will be associated with an organisation")]
        public async Task ThenTheAccountWillBeAssociatedWithAnOrganisation()
        {
            var enteredUser = (User)Context["BuyingUser"];
            var retrievedUser = await enteredUser.Retrieve(Test.ConnectionString);
            var expectedOrganisationId = (Guid)Context["OrganisationId"];
            retrievedUser.PrimaryOrganisationId.Should().Be(expectedOrganisationId);
        }

        [Then(@"the display name will be the first name and last name on the account creation confirmation screen")]
        public void ThenTheDisplayNameWillBeTheFirstNameAndLastNameOnTheAccountCreationConfirmationScreen()
        {
            var pageTitle = Test.Pages.CreateBuyerUser.GetConfirmationTitle();
            var enteredUser = (User)Context["BuyingUser"];
            var expectedDisplayName = User.ConcatDisplayName(enteredUser);
            pageTitle.Should().Contain(expectedDisplayName);
        }

        [Given(@"I enter too long an email address")]
        public async Task GivenIEnterTooLongAnEmailAddress()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            var longname = new Faker().Random.AlphaNumeric(257);
            user.Email = new Faker().Internet.Email(firstName: longname);
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter too long a first name")]
        public async Task GivenIEnterTooLongAFirstName()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            user.FirstName = new Faker().Random.AlphaNumeric(101);
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter too long a last name")]
        public async Task GivenIEnterTooLongALastName()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            user.LastName = new Faker().Random.AlphaNumeric(101);
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter too long a phone number")]
        public async Task GivenIEnterTooLongAPhoneNumber()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(primaryOrganisationId: currentOrganisation.OrganisationId);
            user.PhoneNumber = string.Join(string.Empty, new Faker().Random.Digits(36));
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter an invalid email address format")]
        public async Task GivenIEnterAnInvalidEmailAddressFormat()
        {
            var odsCode = (string)Context["ODSCode"];
            var currentOrganisation = await Organisation.RetrieveByODSCode(Test.ConnectionString, odsCode);
            var user = new User().GenerateRandomUser(true, currentOrganisation.OrganisationId);
            user.Email = new Faker().Internet.Email(provider: "in@valid");
            Context.Add("BuyingUser", user);
        }

        [Then(@"the user is informed that the email address is too long")]
        public void ThenTheUserIsInformedThatTheEmailAddressIsTooLong()
        {
            Test.Pages.CreateBuyerUser.EmailTooLongErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that the first name is too long")]
        public void ThenTheUserIsInformedThatTheFirstNameIsTooLong()
        {
            Test.Pages.CreateBuyerUser.FirstNameTooLongErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that the last name is too long")]
        public void ThenTheUserIsInformedThatTheLastNameIsTooLong()
        {
            Test.Pages.CreateBuyerUser.LastNameTooLongErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that the phone number is too long")]
        public void ThenTheUserIsInformedThatThePhoneNumberIsTooLong()
        {
            Test.Pages.CreateBuyerUser.PhoneNumberTooLongErrorDisplayed().Should().BeTrue();
        }

        [Then(@"the user is informed that the email address is in an invalid format")]
        public void ThenTheUserIsInformedThatTheEmailAddressIsInAnInvalidFormat()
        {
            Test.Pages.CreateBuyerUser.EmailInvalidFormatErrorDisplayed().Should().BeTrue();
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
