using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public sealed class UserAccountsDashboard
    {
        public By OrganisationName => CustomBy.DataTestId("org-page-title");
        public By ODSCode => CustomBy.DataTestId("org-page-ods-code");

        public By EditOrganisation => CustomBy.DataTestId("edit-org-button", "a");
        public By AddUser => CustomBy.DataTestId("add-user-button", "a");
        public By ViewUserLinks => CustomBy.DataTestId("user-table", "a");
        public By UserTable => CustomBy.DataTestId("user-table");
        public By DisabledAccountFlag => By.CssSelector("[data-test-id^=account-disabled-tag]");
        public By UserNameLink => By.CssSelector("[data-test-id^=user-name]");
    }
}
