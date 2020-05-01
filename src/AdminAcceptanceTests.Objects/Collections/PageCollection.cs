﻿using AdminAcceptanceTests.Objects.Pages;

namespace AdminAcceptanceTests.Objects.Collections
{
    public sealed class PageCollection
    {
        public Homepage Homepage { get; set; }
        public Login Login { get; set; }
        public RequestAnAccount RequestAnAccount { get; set; }
        public RequestPasswordReset RequestPasswordReset { get; set; }
        public SetNewPassword SetNewPassword { get; set; }
        public AcceptAgreement AcceptAgreement { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
        public UserAccountsDashboard UserAccountsDashboard { get; set; }
        public CreateBuyerUser CreateBuyerUser { get; set; }
        public ViewUserDetails ViewUserDetails { get; set; }
        public CreateBuyingOrganisation CreateBuyingOrganisation { get; set; }
        public EditOrganisation EditOrganisation { get; set; }
    }
}
