using AdminAcceptanceTests.Actions.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Collections
{
    public sealed class PageActionCollection
    {
        public Homepage Homepage { get; set; }
        public Authorization Authorization { get; set; }
        public OrganisationDashboard OrganisationDashboard { get; set; }
    }
}
