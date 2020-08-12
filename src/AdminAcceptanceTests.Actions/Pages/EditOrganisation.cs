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
            Wait.Until(d => d.FindElements(Pages.EditOrganisation.PageTitle).Count > 0);
            Wait.Until(d => d.FindElement(Pages.EditOrganisation.PageTitle).Displayed);
        }

        public void Save()
        {
            Driver.FindElement(Pages.EditOrganisation.Save).Click();
        }

        public bool ConfirmationPageDisplayed()
        {
            return Driver.FindElements(Pages.EditOrganisation.Confirmation).Count > 0;
        }
    }
}
