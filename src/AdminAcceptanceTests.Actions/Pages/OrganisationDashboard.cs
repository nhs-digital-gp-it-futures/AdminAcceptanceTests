namespace AdminAcceptanceTests.Actions.Pages
{
    using System.Linq;
    using AdminAcceptanceTests.Actions.Utils;
    using AdminAcceptanceTests.TestData.Information;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    

    public sealed class OrganisationDashboard : PageAction
    {
        public OrganisationDashboard(IWebDriver driver)
            : base(driver)
        {
        }

        public void PageDisplayed()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.OrganisationDashboard.OrgDashboardTitle).Count == 1);
        }

        public bool AddOrganisationsButtonIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.OrganisationDashboard.AddOrgButton).Count > 0;
        }

        public bool LinksToManageOrganisationsAreDisplayed()
        {
            return Driver.FindElements(Objects.Pages.OrganisationDashboard.OrganisationLinks).Count > 0;
        }

        public IEnumerable<string> GetOrganisationNames()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.OrganisationName).Select(s => s.Text);
        }

        public void ClickAddOrganisationsButton()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.OrganisationDashboard.AddOrgButton).Count > 0);
            Driver.FindElement(Objects.Pages.OrganisationDashboard.AddOrgButton).Click();
        }

        public string SelectOrganisation(int? index = null)
        {
            Wait.Until(d => d.FindElements(Objects.Pages.OrganisationDashboard.OrganisationLinks).Count > 0);
            var organisations = Driver.FindElements(Objects.Pages.OrganisationDashboard.OrganisationLinks);

            IWebElement org;

            if (index is null)
            {
                org = RandomInformation.GetRandomItem(organisations);
            }
            else
            {
                org = organisations[index.Value];
            }

            var orgName = org.Text;
            Wait.Until(d => d.FindElement(By.LinkText(org.Text)).Displayed);
            Wait.Until(ElementExtensions.ElementToBeClickable(By.LinkText(org.Text)));
            org.Click();
            return orgName;
        }

        public void SelectNamedOrganisation(string organisationName)
        {
            Wait.WaitForJsToComplete();
            Wait.Until(d => d.FindElements(By.LinkText(organisationName)).Count == 1);
            Wait.Until(ElementExtensions.ElementToBeClickable(By.LinkText(organisationName)));
            Driver.FindElement(By.LinkText(organisationName)).Click();
        }
    }
}
