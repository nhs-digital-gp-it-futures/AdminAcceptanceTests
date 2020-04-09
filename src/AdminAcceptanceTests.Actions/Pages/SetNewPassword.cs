using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class SetNewPassword : PageAction
    {
        public SetNewPassword(IWebDriver driver) : base(driver)
        {

        }

        public bool PageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.SetNewPassword.PageTitle).Count > 0);
            return Driver.FindElement(Pages.SetNewPassword.PageTitle).Displayed;
        }

        public void EnterFirstPassword(string value)
        {
            Wait.Until(d => d.FindElements(Pages.SetNewPassword.Password1).Count > 0);
            Driver.FindElement(Pages.SetNewPassword.Password1).SendKeys(value);
        }

        public void EnterSecondPassword(string value)
        {
            Wait.Until(d => d.FindElements(Pages.SetNewPassword.Password2).Count > 0);
            Driver.FindElement(Pages.SetNewPassword.Password2).SendKeys(value);
        }

        public void Submit()
        {
            Driver.FindElement(Pages.SetNewPassword.Submit).Click();
        }

        public bool ConfirmationDisplayed()
        {
            return Driver.FindElements(Pages.SetNewPassword.Confirmation).Count > 0;
        }

        public bool ErrorDisplayed()
        {
            return Driver.FindElements(Pages.SetNewPassword.Error).Count > 0;
        }

        public void GoToLoginPage()
        {
            Driver.FindElement(Pages.SetNewPassword.GoToLoginLink).Click();
        }
    }
}
