using AdminAcceptanceTests.Actions.Utils;
using FluentAssertions;
using OpenQA.Selenium;
using System;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class UserAccountsDashboard : PageAction
    {
        public UserAccountsDashboard(IWebDriver driver) : base(driver)
        {
        }

        public void OrganisationNameMatches(string organisationName)
        {
            Wait.Until(d => d.FindElement(Pages.UserAccountsDashboard.OrganisationName).Displayed);
            var name = Driver.FindElement(Pages.UserAccountsDashboard.OrganisationName).Text;

            name.Should().BeEquivalentTo(organisationName);
        }

        public string GetODSCode()
        {
            return Driver.FindElement(Pages.UserAccountsDashboard.ODSCode).Text;
        }

        public bool EditOrganisationButtonDisplayed()
        {
            return ElementDisplayed(Pages.UserAccountsDashboard.EditOrganisation);
        }
        public void ClickEditOrganisationButton()
        {
            Driver.FindElement(Pages.UserAccountsDashboard.EditOrganisation).Click();
        }

        public bool AddUserButtonDisplayed()
        {
            return ElementDisplayed(Pages.UserAccountsDashboard.AddUser);
        }

        public void ClickAddUserButton()
        {
            Driver.FindElement(Pages.UserAccountsDashboard.AddUser).Click();
        }

        private bool ElementDisplayed(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
