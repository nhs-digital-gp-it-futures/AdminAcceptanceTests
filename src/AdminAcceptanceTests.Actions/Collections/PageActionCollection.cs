﻿using AdminAcceptanceTests.Actions.Pages;

namespace AdminAcceptanceTests.Actions.Collections
{
    public sealed class PageActionCollection
    {
        public Homepage Homepage { get; set; }
        public Authorization Authorization { get; set; }
        public RequestAnAccount RequestAnAccount { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
        public UserAccountsDashboard UserAccountsDashboard { get; set; }
        public CreateBuyerUser CreateBuyerUser { get; set; }
        public EditOrganisation EditOrganisation { get; set; }
    }
}
