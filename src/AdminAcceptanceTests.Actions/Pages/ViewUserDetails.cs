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
           Wait.Until(d => d.FindElement(Pages.ViewUserDetails.PageTitle).Displayed);
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
    }
}
