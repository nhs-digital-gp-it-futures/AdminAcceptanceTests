using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public sealed class OrganisationDashboard
    {
        public By OrgDashboardTitle = CustomBy.DataTestId("org-dashboard-title");
        public By AddOrgButton => CustomBy.DataTestId("add-org-button", "a");
        public By OrganisationLinks => CustomBy.DataTestId("org-table", "a");
    }
}
