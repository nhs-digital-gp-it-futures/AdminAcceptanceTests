namespace AdminAcceptanceTests.Actions.Pages
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.TestData.Information;
using FluentAssertions;
using OpenQA.Selenium;
public sealed class UserAccountsDashboard : PageAction
    {
        public UserAccountsDashboard(IWebDriver driver)
            : base(driver)
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

        public bool OrgNameAndODSCodeIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.OrganisationName).Count > 0 && Driver.FindElements(Objects.Pages.UserAccountsDashboard.ODSCode).Count > 0;
        }

        public bool EditOrganisationButtonDisplayed()
        {
            return ElementDisplayed(Objects.Pages.UserAccountsDashboard.EditOrganisation);
        }

        public List<string> OrganisationNames()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.RadioButtonLabel).Select(s => s.Text).ToList();
        }

        public IEnumerable<string> GetRelatedODSCodes()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.RelatedOdsCodes).Select(o => o.Text);
        }

        public bool AddOrganisationPageDisplayed()
        {
            return ElementDisplayed(Objects.Pages.UserAccountsDashboard.OrganisationName);
        }

        public bool AddAnOrganisationButtonDisplayed()
        {
            return ElementDisplayed(Objects.Pages.UserAccountsDashboard.AddAnOrganisationButton);
        }

        public void ClickAddAnOrganisationButton()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.AddAnOrganisationButton).Click();
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

        public bool ConfirmButtonDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.ConfirmButton).Count == 1;
        }

        public void ClickConfirmButton()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.ConfirmButton).Click();
        }

        public void ClickBackLink()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.BackLink).Click();
        }

        public void ClickRemoveLink()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.RemoveLink).Click();
        }

        public List<string> GetRadioButtonText()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.RadioButton).Select(s => s.Text).ToList();
        }

        public int NumberOfRadioButtonsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.RadioButton).Count;
        }

        public string ClickRadioButton(int index = 0)
        {
            Wait.Until(d => NumberOfRadioButtonsDisplayed() > index);
            var element = Driver.FindElements(Objects.Pages.UserAccountsDashboard.RadioButton)[index];
            element.Click();
            Wait.Until(s => bool.Parse(s.FindElements(Objects.Pages.UserAccountsDashboard.RadioButton)[index].GetProperty("checked")));
            return element.GetAttribute("value");
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

            var userName = user.Text;
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

        public bool ExpectedUserHasDisabledFlag(string username)
        {
            var rows = Driver.FindElement(Objects.Pages.UserAccountsDashboard.UserTable).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));

            var row = rows.Single(s => s.FindElement(By.TagName("a")).Text.Equals(username, StringComparison.OrdinalIgnoreCase));

            return row.FindElements(Objects.Pages.UserAccountsDashboard.DisabledAccountFlag).Count == 1;
        }

        public bool ErrorSummaryDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.ErrorSummary).Count > 0;
        }

        public bool ErrorMessagesDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.ErrorMessages).Count > 0;
        }

        public bool RemoveLinkDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.RemoveLink).Count > 0;
        }

        public bool RemoveButtonDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.RemoveButton).Count > 0;
        }

        public void ClickRemoveButton()
        {
            Driver.FindElement(Objects.Pages.UserAccountsDashboard.RemoveButton).Click();
        }

        public bool NamedPageTitleDisplayed(string namedSectionPageTitle)
        {
            try
            {
                Wait.Until(d => d.FindElement(Objects.Pages.UserAccountsDashboard.OrganisationName).Text.Contains(namedSectionPageTitle, StringComparison.OrdinalIgnoreCase));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ClickCheckboxReturnName(int index = 0)
        {
            Wait.Until(d => NumberOfRadioButtonsDisplayed() > index);
            var element = Driver.FindElements(Objects.Pages.UserAccountsDashboard.RadioButton)[index];
            element.Click();
            Wait.Until(d => bool.Parse(d.FindElements(Objects.Pages.UserAccountsDashboard.RadioButton)[index].GetProperty("checked")));
            return element.GetAttribute("name");
        }

        public bool RelatedNameAndOdsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.UserAccountsDashboard.OrganisationName).Count > 0 && Driver.FindElements(Objects.Pages.UserAccountsDashboard.ODSCode).Count > 0;
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
