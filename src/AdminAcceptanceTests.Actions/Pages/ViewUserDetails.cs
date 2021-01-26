namespace AdminAcceptanceTests.Actions.Pages
{
    using AdminAcceptanceTests.Actions.Utils;
    using OpenQA.Selenium;

    public sealed class ViewUserDetails : PageAction
    {
        public ViewUserDetails(IWebDriver driver)
            : base(driver)
        {
        }

        public void PageDisplayed()
        {
           Wait.WaitForJsToComplete();
           Wait.Until(d => d.FindElements(Objects.Pages.ViewUserDetails.PageTitle).Count == 1);
        }

        public bool NameDisplayed()
        {
            return Driver.FindElement(Objects.Pages.ViewUserDetails.Name).Displayed;
        }

        public string GetName()
        {
            return Driver.FindElement(Objects.Pages.ViewUserDetails.Name).Text;
        }

        public bool ContactDetailsDisplayed()
        {
            return Driver.FindElement(Objects.Pages.ViewUserDetails.ContactDetails).Displayed;
        }

        public bool EmailAddressDisplayed()
        {
            return Driver.FindElement(Objects.Pages.ViewUserDetails.EmailAddress).Displayed;
        }

        public bool OrganisationNameDisplayed()
        {
            return Driver.FindElement(Objects.Pages.ViewUserDetails.OrganisationName).Displayed;
        }

        public void DisableAccount()
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.ViewUserDetails.DisableUserButton));
            Driver.FindElement(Objects.Pages.ViewUserDetails.DisableUserButton).Click();
            Wait.Until(d => d.FindElements(Objects.Pages.ViewUserDetails.DisabledReenableUserConfirmationPageTitle).Count > 0);
        }
    }
}
