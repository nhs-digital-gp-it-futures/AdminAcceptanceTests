using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class ViewUserDetails
    {
        public static By PageTitle => CustomBy.DataTestId("view-user-page-title");
        public static By OrganisationName => CustomBy.DataTestId("organisation-name");
        public static By Name => CustomBy.DataTestId("user-name");
        public static By ContactDetails => CustomBy.DataTestId("user-contact-details");
        public static By EmailAddress => CustomBy.DataTestId("user-email");
        public static By DisableUserButton => CustomBy.DataTestId("change-account-status-button", "button");
        public static By DisabledReenableUserConfirmationPageTitle => By.CssSelector("[data-test-id$=-user-confirmation-page-title]");
    }
}
