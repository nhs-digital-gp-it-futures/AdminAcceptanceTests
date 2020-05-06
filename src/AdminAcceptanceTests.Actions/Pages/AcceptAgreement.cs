using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class AcceptAgreement : PageAction
    {

        public AcceptAgreement(IWebDriver driver) : base(driver)
        {

        }

        public void PageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.AcceptAgreement.SubmitButton).Count > 0);
        }

        public void PageNotDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.AcceptAgreement.SubmitButton).Count == 0);
        }

        public void ClickCheckbox()
        {
            Wait.Until(d => d.FindElements(Pages.AcceptAgreement.Checkbox).Count == 1);
            Driver.FindElement(Pages.AcceptAgreement.Checkbox).Click();
        }

        public void Submit()
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.AcceptAgreement.SubmitButton));
            Driver.FindElement(Pages.AcceptAgreement.SubmitButton).Click();
        }

        public bool ErrorDisplayed()
        {
            return Driver.FindElements(Pages.AcceptAgreement.ErrorSummary).Count > 0;
        }
    }
}
