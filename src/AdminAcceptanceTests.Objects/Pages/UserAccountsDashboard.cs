using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class UserAccountsDashboard
    {
        public static By OrganisationName => CustomBy.DataTestId("org-page-title");
        public static By ODSCode => CustomBy.DataTestId("org-page-ods-code");

        public static By EditOrganisation => CustomBy.DataTestId("edit-org-button", "a");
        public static By AddUser => CustomBy.DataTestId("add-user-button", "a");
        public static By ViewUserLinks => CustomBy.DataTestId("user-table", "a");
        public static By UserTable => CustomBy.DataTestId("user-table");
        public static By DisabledAccountFlag => By.CssSelector("[data-test-id^=account-disabled-tag]");
        public static By UserNameLink => By.CssSelector("[data-test-id^=user-name]");
    }
}
