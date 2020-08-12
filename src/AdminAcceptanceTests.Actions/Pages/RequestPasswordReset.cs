using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class RequestPasswordReset : PageAction
    {
        public RequestPasswordReset(IWebDriver driver) : base(driver)
        {

        }

        public void EnterEmail(string value)
        {
            Wait.Until(d => d.FindElements(Pages.Login.ForgotPassword).Count == 0);
            Wait.Until(d => d.FindElements(Pages.RequestPasswordReset.Email).Count > 0);
            Driver.FindElement(Pages.RequestPasswordReset.Email).SendKeys(value);
        }

        public void Submit()
        {
            Driver.FindElement(Pages.RequestPasswordReset.Submit).Click();
        }

        public bool ConfirmationDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.RequestPasswordReset.ConfirmationPage).Count > 0);
            return Driver.FindElement(Pages.RequestPasswordReset.ConfirmationPage).Displayed;
        }
    }
}
