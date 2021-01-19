using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class EditOrganisation : PageAction
    {
        public EditOrganisation(IWebDriver driver) : base(driver)
        {

        }

        public void PageDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.EditOrganisation.PageTitle).Count > 0);
            Wait.Until(d => d.FindElement(Objects.Pages.EditOrganisation.PageTitle).Displayed);
        }

        public void Save()
        {
            Driver.FindElement(Objects.Pages.EditOrganisation.Save).Click();
        }

        public bool ConfirmationPageDisplayed()
        {
            return Driver.FindElements(Objects.Pages.EditOrganisation.Confirmation).Count > 0;
        }
    }
}
