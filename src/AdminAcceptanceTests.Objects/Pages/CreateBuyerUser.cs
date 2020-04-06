using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class CreateBuyerUser
    {
        public By Title => CustomBy.DataTestId("add-user-page-title");
        public By FirstName => By.Id("firstName");
        public By LastName => By.Id("lastName");
        public By PhoneNumber => By.Id("phoneNumber");
        public By EmailAddress => By.Id("emailAddress");
        public By CreateUser => CustomBy.DataTestId("add-user-button", "button");
        public By ErrorSummary => CustomBy.DataTestId("error-summary");
        public By EmailRequired => By.LinkText("Email address is required");
        public By EmailTooLong => By.LinkText("Email address is too long");
        public By EmailInvalidFormat => By.LinkText("Email address format is not valid");
        public By EmailAlreadyExists => By.LinkText("Email address already exists");
        public By PhoneNumberRequired => By.LinkText("Telephone number is required");
        public By FirstNameRequired => By.LinkText("First name is required");
        public By FirstNameTooLong => By.LinkText("First name is too long");
        public By LastNameRequired => By.LinkText("Last name is required");
        public By LastNameTooLong => By.LinkText("Last name is too long");
        public By PhoneNumberTooLong => By.LinkText("Telephone number is too long");
    }
}
