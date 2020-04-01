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
        public By CreateUser => CustomBy.DataTestId("add-user-button");
        public By ErrorSummary => CustomBy.DataTestId("error-summary");
        public By EmailRequired => By.Id("EmailRequired");
        public By EmailTooLong => By.Id("EmailTooLong");
        public By EmailInvalidFormat => By.Id("EmailInvalidFormat");
        public By EmailAlreadyExists => By.Id("EmailAlreadyExists");
        public By PhoneNumberRequired => By.Id("PhoneNumberRequired");
        public By FirstNameRequired => By.Id("FirstNameRequired");
        public By FirstNameTooLong => By.Id("FirstNameTooLong");
        public By LastNameRequired => By.Id("LastNameRequired");
        public By LastNameTooLong => By.Id("LastNameTooLong");
    }
}
