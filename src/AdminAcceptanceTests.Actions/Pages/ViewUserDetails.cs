using OpenQA.Selenium;
using AdminAcceptanceTests.Actions.Utils;
using System;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class ViewUserDetails : PageAction
    {
        public ViewUserDetails(IWebDriver driver) : base(driver)
        {

        }

        public void PageDisplayed()
        {
           Driver.WaitForJsToComplete(Wait);
           Wait.Until(d => d.FindElements(Pages.ViewUserDetails.PageTitle).Count == 1);
        }

        public bool NameDisplayed()
        {
            return Driver.FindElement(Pages.ViewUserDetails.Name).Displayed;
        }

        public string GetName()
        {
            return Driver.FindElement(Pages.ViewUserDetails.Name).Text;
        }

        public bool ContactDetailsDisplayed()
        {
            return Driver.FindElement(Pages.ViewUserDetails.ContactDetails).Displayed;
        }

        public bool EmailAddressDisplayed()
        {
            return Driver.FindElement(Pages.ViewUserDetails.EmailAddress).Displayed;
        }

        public bool OrganisationNameDisplayed()
        {
            return Driver.FindElement(Pages.ViewUserDetails.OrganisationName).Displayed;
        }

        public void DisableAccount()
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.ViewUserDetails.DisableUserButton));
            Driver.FindElement(Pages.ViewUserDetails.DisableUserButton).Click();
            Wait.Until(d => d.FindElements(Pages.ViewUserDetails.DisabledReenableUserConfirmationPageTitle).Count == 1);
        }
    }
}
