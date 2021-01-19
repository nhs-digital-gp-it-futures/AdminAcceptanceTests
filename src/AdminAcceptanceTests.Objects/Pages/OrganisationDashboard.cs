using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class OrganisationDashboard
    {
        public static By OrgDashboardTitle => CustomBy.DataTestId("org-dashboard-title");

        public static By AddOrgButton => CustomBy.DataTestId("add-org-button", "a");
        public static By OrganisationLinks => CustomBy.DataTestId("org-table", "a");
    }
}
