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
            Wait.Until(d => d.FindElements(Objects.Pages.SetNewPassword.PageTitle).Count > 0);
            return Driver.FindElement(Objects.Pages.SetNewPassword.PageTitle).Displayed;
        }

        public void EnterFirstPassword(string value)
        {
            Wait.Until(d => d.FindElements(Objects.Pages.SetNewPassword.Password1).Count > 0);
            Driver.FindElement(Objects.Pages.SetNewPassword.Password1).SendKeys(value);
        }

        public void EnterSecondPassword(string value)
        {
            Wait.Until(d => d.FindElements(Objects.Pages.SetNewPassword.Password2).Count > 0);
            Driver.FindElement(Objects.Pages.SetNewPassword.Password2).SendKeys(value);
        }

        public void Submit()
        {
            Driver.FindElement(Objects.Pages.SetNewPassword.Submit).Click();
        }

        public bool ConfirmationDisplayed()
        {
            Wait.WaitForJsToComplete();
            return Driver.FindElements(Objects.Pages.SetNewPassword.Confirmation).Count > 0;
        }

        public bool ErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.SetNewPassword.Error).Count > 0;
        }

        public void GoToLoginPage()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.SetNewPassword.GoToLoginLink).Count == 1);
            Driver.FindElement(Objects.Pages.SetNewPassword.GoToLoginLink).Click();
            Wait.Until(d => d.FindElements(Objects.Pages.SetNewPassword.Confirmation).Count == 0);
        }
    }
}
