using AdminAcceptanceTests.Objects.Pages;

namespace AdminAcceptanceTests.Objects.Collections
{
    public sealed class PageCollection
    {
        public Homepage Homepage { get; set; }
        public Login Login { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
        public UserAccountsDashboard UserAccountsDashboard { get; set; }
    }
}
