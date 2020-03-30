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
            var name = Driver.FindElement(Pages.UserAccountsDashboard.OrganisationName).Text;

            name.Should().BeEquivalentTo(organisationName);
        }

        public String GetODSCode()
        {
            return Driver.FindElement(Pages.UserAccountsDashboard.ODSCode).Text;
        }

        public bool EditOrganisationButtonDisplayed()
        {
            return ElementDisplayed(Pages.UserAccountsDashboard.EditOrganisation);
        }

        public bool AddUserButtonDisplayed()
        {
            return ElementDisplayed(Pages.UserAccountsDashboard.AddUser);
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
