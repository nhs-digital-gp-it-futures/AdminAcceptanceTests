using AdminAcceptanceTests.Actions.Collections;
using AdminAcceptanceTests.Actions.Pages;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                Homepage = new Pages.Homepage(driver),
                Authorization = new Pages.Authorization(driver),
                UserAccountsDashboard = new UserAccountsDashboard(driver),
                EditOrganisation = new EditOrganisation(driver),
                CreateBuyerUser = new CreateBuyerUser(driver),
                ViewUserDetails = new ViewUserDetails(driver),
                RequestAnAccount = new Pages.RequestAnAccount(driver),
                OrganisationDashboard = new Pages.OrganisationDashboard(driver)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
