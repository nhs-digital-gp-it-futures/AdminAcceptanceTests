using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class OrganisationDashboard : PageAction
    {
        public OrganisationDashboard(IWebDriver driver) : base(driver)
        {

        }

        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.OrganisationDashboard.OrgDashboardTitle).Displayed);
        }

        public bool AddOrganisationsButtonIsDisplayed()
        {
            return driver.FindElements(pages.OrganisationDashboard.AddOrgButton).Count > 0;
        }

        public bool LinksToManageOrganisationsAreDisplayed()
        {
            return driver.FindElements(pages.OrganisationDashboard.OrganisationLinks).Count > 0;
        }
    }
}
