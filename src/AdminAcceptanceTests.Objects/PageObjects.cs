using AdminAcceptanceTests.Objects.Collections;
using AdminAcceptanceTests.Objects.Pages;

namespace AdminAcceptanceTests.Objects
{
    public sealed class PageObjects
    {
        public PageObjects()
        {
            Pages = new PageCollection
            {
                Homepage = new Homepage(),
                Login = new Login(),
                OrganisationDashboard = new OrganisationDashboard(),
                UserAccountsDashboard = new UserAccountsDashboard()
            };
        }
        public PageCollection Pages { get; set; }
    }
}
