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
    }
}
