using AdminAcceptanceTests.Objects.Pages;

namespace AdminAcceptanceTests.Objects.Collections
{
    public sealed class PageCollection
    {
        public Homepage Homepage { get; set; }
        public Login Login { get; set; }
        public RequestAnAccount RequestAnAccount { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
    }
}
