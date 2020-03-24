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
                OrganisationDashboard = new Pages.OrganisationDashboard(driver),
                UserAccountsDashboard = new UserAccountsDashboard(driver)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
