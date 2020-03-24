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
            Wait.Until(s => s.FindElement(Pages.OrganisationDashboard.OrgDashboardTitle).Displayed);
        }

        public bool AddOrganisationsButtonIsDisplayed()
        {
            return Driver.FindElements(Pages.OrganisationDashboard.AddOrgButton).Count > 0;
        }

        public bool LinksToManageOrganisationsAreDisplayed()
        {
            return Driver.FindElements(Pages.OrganisationDashboard.OrganisationLinks).Count > 0;
        }
    }
}
