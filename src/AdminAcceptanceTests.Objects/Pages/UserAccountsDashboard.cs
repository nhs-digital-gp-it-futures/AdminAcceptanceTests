using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public sealed class UserAccountsDashboard
    {
        public By OrganisationName => CustomBy.DataTestId("org-page-title");

        public By EditOrganisation => CustomBy.DataTestId("edit-org-button", "a");
        public By AddUser => CustomBy.DataTestId("add-user-button", "a");
    }
}
