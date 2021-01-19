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
            Wait.Until(d => d.FindElements(Objects.Pages.UserAccountsDashboard.OrganisationName).Count == 1);
            var name = Driver.FindElement(Objects.Pages.UserAccountsDashboard.OrganisationName).Text;

            name.Should().BeEquivalentTo(organisationName);
        }

        public string GetODSCode()
        {
            return Driver.FindElement(Objects.Pages.UserAccountsDashboard.ODSCode).Text;
        }

        public bool EditOrganisationButtonDisplayed()
        {
            return ElementDisplayed(Objects.Pages.UserAccountsDashboard.EditOrganisation);
        }
        public void ClickEditOrganisationButton()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.EditOrganisation).Click();
        }

        public bool AddUserButtonDisplayed()
        {
            return ElementDisplayed(Objects.Pages.UserAccountsDashboard.AddUser);
        }

        public void ClickAddUserButton()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.AddUser).Click();
        }

        public bool ViewUserLinksDisplayed()
        {
            Wait.WaitForJsToComplete();
            return ElementDisplayed(Objects.Pages.UserAccountsDashboard.ViewUserLinks);
        }

        public string ClickUserLink(int? index = null)
        {
            Wait.Until(d => d.FindElements(Objects.Pages.UserAccountsDashboard.ViewUserLinks).Count > 0);
            var users = Driver.FindElements(Objects.Pages.UserAccountsDashboard.ViewUserLinks);

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
            Wait.WaitForJsToComplete();
            Wait.Until(ElementExtensions.ElementToBeClickable(By.LinkText(name)));
            Driver.FindElement(By.LinkText(name)).Click();
            Wait.Until(ElementExtensions.InvisibilityOfElement(By.LinkText(name)));
        }

        public bool ExpectedUserHasDisabledFlag(string Username)
        {
            var rows = Driver.FindElement(Objects.Pages.UserAccountsDashboard.UserTable).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));

            var row = rows.Single(s => s.FindElement(By.TagName("a")).Text.Equals(Username, StringComparison.OrdinalIgnoreCase));

            return row.FindElements(Objects.Pages.UserAccountsDashboard.DisabledAccountFlag).Count == 1;
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
