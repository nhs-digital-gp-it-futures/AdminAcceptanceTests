using AdminAcceptanceTests.Actions.Pages;

namespace AdminAcceptanceTests.Actions.Collections
{
    public sealed class PageActionCollection
    {
        public Homepage Homepage { get; set; }
        public Authorization Authorization { get; set; }
        public RequestAnAccount RequestAnAccount { get; set; }
        public RequestPasswordReset RequestPasswordReset { get; set; }
        public SetNewPassword SetNewPassword { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
        public UserAccountsDashboard UserAccountsDashboard { get; set; }
        public CreateBuyerUser CreateBuyerUser { get; set; }
        public ViewUserDetails ViewUserDetails { get; set; }
        public EditOrganisation EditOrganisation { get; set; }
    }
}
