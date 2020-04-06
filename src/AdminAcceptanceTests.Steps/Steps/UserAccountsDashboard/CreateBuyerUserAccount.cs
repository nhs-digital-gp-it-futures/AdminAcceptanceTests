using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using Bogus;
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

        [Given(@"account details have been provided")]
        public void GivenAccountDetailsHaveBeenProvided()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId: CurrentOrganisation.OrganisationId);
            Context.Add("BuyingUser", user);
            Context.Add("OrganisationId", CurrentOrganisation.OrganisationId);
        }

        [Given(@"that mandatory data '(.*)' has not been added")]
        public void GivenThatMandatoryDataHasNotBeenAdded(string MissingField)
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId: CurrentOrganisation.OrganisationId);

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
                case "phone number":
                    user.PhoneNumber = "";
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
            User user = new User().GenerateRandomUser(PrimaryOrganisationId: CurrentOrganisation.OrganisationId);
            user.Email = "alicesmith@email.com";
            Context.Add("BuyingUser", user);
        }

        [When(@"I create the buying user account")]
        public void WhenICreateTheBuyingUserAccount()
        {
            CompleteAndSubmitForm();
            //wait for confirmation page => data-test-id="add-user-confirmation"
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
        public void ThenTheAccountWillBeAssociatedWithAnOrganisation()
        {
            var enteredUser = (User)Context["BuyingUser"];
            var retrievedUser = enteredUser.Retrieve(Test.ConnectionString);
            var expectedOrganisationId = (Guid)Context["OrganisationId"];
            retrievedUser.PrimaryOrganisationId.Should().Be(expectedOrganisationId);
        }

        [Given(@"I enter too long an email address")]
        public void GivenIEnterTooLongAnEmailAddress()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId: CurrentOrganisation.OrganisationId);
            var longname = new Faker().Random.AlphaNumeric(257);
            user.Email = new Faker().Internet.Email(firstName:longname);
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter too long a first name")]
        public void GivenIEnterTooLongAFirstName()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId:CurrentOrganisation.OrganisationId);
            user.FirstName = new Faker().Random.AlphaNumeric(99);
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter too long a last name")]
        public void GivenIEnterTooLongALastName()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId:CurrentOrganisation.OrganisationId);
            user.LastName = new Faker().Random.AlphaNumeric(99);
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter too long a phone number")]
        public void GivenIEnterTooLongAPhoneNumber()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(PrimaryOrganisationId: CurrentOrganisation.OrganisationId);
            user.PhoneNumber = string.Join("", new Faker().Random.Digits(36));
            Context.Add("BuyingUser", user);
        }

        [Given(@"I enter an invalid email address format")]
        public void GivenIEnterAnInvalidEmailAddressFormat()
        {
            string ODSCode = (string)Context["ODSCode"];
            var CurrentOrganisation = new Organisation().RetrieveByODSCode(Test.ConnectionString, ODSCode);
            User user = new User().GenerateRandomUser(true, CurrentOrganisation.OrganisationId);
            user.Email = new Faker().Internet.Email(provider:"in@valid");
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
