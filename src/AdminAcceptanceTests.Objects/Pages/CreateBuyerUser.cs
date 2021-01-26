namespace AdminAcceptanceTests.Objects.Pages
{
    using AdminAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class CreateBuyerUser
    {
        public static By Title => CustomBy.DataTestId("add-user-page-title");

        public static By FirstName => By.Id("firstName");

        public static By LastName => By.Id("lastName");

        public static By PhoneNumber => By.Id("phoneNumber");

        public static By EmailAddress => By.Id("emailAddress");

        public static By CreateUser => CustomBy.DataTestId("add-user-button", "button");

        public static By ConfirmationTitle => CustomBy.DataTestId("add-user-confirmation-page-title");

        public static By ErrorSummary => CustomBy.DataTestId("error-summary");

        public static By EmailRequired => By.LinkText("Email address is required");

        public static By EmailTooLong => By.LinkText("Email address is too long");

        public static By EmailInvalidFormat => By.LinkText("Email address format is not valid");

        public static By EmailAlreadyExists => By.LinkText("Email address already exists");

        public static By PhoneNumberRequired => By.LinkText("Telephone number is required");

        public static By FirstNameRequired => By.LinkText("First name is required");

        public static By FirstNameTooLong => By.LinkText("First name is too long");

        public static By LastNameRequired => By.LinkText("Last name is required");

        public static By LastNameTooLong => By.LinkText("Last name is too long");

        public static By PhoneNumberTooLong => By.LinkText("Telephone number is too long");
    }
}
