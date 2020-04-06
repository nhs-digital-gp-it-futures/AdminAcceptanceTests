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
                UserAccountsDashboard = new UserAccountsDashboard(),
                EditOrganisation = new EditOrganisation(),
                CreateBuyerUser = new CreateBuyerUser(),
                ViewUserDetails = new ViewUserDetails(),
                RequestAnAccount = new RequestAnAccount()
            };
        }
        public PageCollection Pages { get; set; }
    }
}
