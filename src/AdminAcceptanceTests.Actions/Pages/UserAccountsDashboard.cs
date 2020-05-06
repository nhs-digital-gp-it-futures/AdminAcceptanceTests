using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.TestData.Information;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class UserAccountsDashboard : PageAction
    {
        public UserAccountsDashboard(IWebDriver driver) : base(driver)
        {
        }

        public void OrganisationNameMatches(string organisationName)
        {
            Wait.Until(d => d.FindElements(Pages.UserAccountsDashboard.OrganisationName).Count == 1);
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
            Wait.Until(d => d.FindElements(Pages.UserAccountsDashboard.AddUser).Count == 0);
        }

        public bool ViewUserLinksDisplayed()
        {
            Driver.WaitForJsToComplete(Wait);
            return ElementDisplayed(Pages.UserAccountsDashboard.ViewUserLinks);
        }

        public string ClickUserLink(int? index = null)
        {
            Wait.Until(d => d.FindElements(Pages.UserAccountsDashboard.ViewUserLinks).Count > 0);
            var users = Driver.FindElements(Pages.UserAccountsDashboard.ViewUserLinks);

            IWebElement user;

            if (index is null)
            {
                user = RandomInformation.GetRandomItem(users);
            }
            else
            {
                user = users[index.Value];
            }

            string userName = user.Text;
            user.Click();
            return userName;
        }

        public void ClickUserLink(string name)
        {
            Thread.Sleep(500);
            Driver.WaitForJsToComplete(Wait);
            Wait.Until(ElementExtensions.ElementToBeClickable(By.LinkText(name)));
            Driver.FindElement(By.LinkText(name)).Click();
            Wait.Until(ElementExtensions.InvisibilityOfElement(By.LinkText(name)));
        }

        public bool ExpectedUserHasDisabledFlag(string Username)
        {
            return Driver.FindElements(Pages.UserAccountsDashboard.DisabledAccountFlag)
                .Where(e => e.FindElement(By.XPath("../../a")).Text.Equals(Username, StringComparison.OrdinalIgnoreCase)).Count() == 1;
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
