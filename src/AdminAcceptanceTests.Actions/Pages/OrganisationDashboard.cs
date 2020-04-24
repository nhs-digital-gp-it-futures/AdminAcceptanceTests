using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.TestData.Information;
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

        public void ClickAddOrganisationsButton()
        {
            Wait.Until(d => d.FindElements(Pages.OrganisationDashboard.AddOrgButton).Count > 0);
            Driver.FindElement(Pages.OrganisationDashboard.AddOrgButton).Click();
        }

        public string SelectOrganisation(int? index = null)
        {
            Wait.Until(d => d.FindElements(Pages.OrganisationDashboard.OrganisationLinks).Count > 0);
            var organisations = Driver.FindElements(Pages.OrganisationDashboard.OrganisationLinks);

            IWebElement org;

            if (index is null)
            {
                org = RandomInformation.GetRandomItem(organisations);
            }
            else
            {
                org = organisations[index.Value];
            }

            string orgName = org.Text;
            org.Click();
            return orgName;
        }

        public void SelectNamedOrganisation(string organisationName)
        {
            Driver.FindElement(By.LinkText(organisationName)).Click();
        }
    }
}
