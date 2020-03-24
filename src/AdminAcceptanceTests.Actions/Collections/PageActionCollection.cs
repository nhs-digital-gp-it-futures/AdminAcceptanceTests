using AdminAcceptanceTests.Actions.Pages;

namespace AdminAcceptanceTests.Actions.Collections
{
    public sealed class PageActionCollection
    {
        public Homepage Homepage { get; set; }
        public Authorization Authorization { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
        public UserAccountsDashboard UserAccountsDashboard { get; set; }
    }
}
