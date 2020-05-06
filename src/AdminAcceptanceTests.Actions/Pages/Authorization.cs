using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class Authorization : PageAction
    {
        public Authorization(IWebDriver driver) : base(driver)
        {
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(Pages.Login.Password).Click();
            Driver.EnterTextViaJs(Wait, Pages.Login.Password, password);
            Wait.Until(d => d.FindElement(Pages.Login.Password).GetAttribute("value") != "");
        }

        public void EnterUsername(string username)
        {
            Driver.WaitForJsToComplete(Wait);
            Wait.Until(d => d.FindElements(Pages.Login.Username).Count == 1);
            Wait.Until(d => d.FindElement(Pages.Login.Username).GetAttribute("value") == "");
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.Login.Username));
            Driver.FindElement(Pages.Login.Username).Click();
            Driver.EnterTextViaJs(Wait, Pages.Login.Username, username);
            Wait.Until(d => d.FindElement(Pages.Login.Username).GetAttribute("value") != "");
        }

        public void Login()
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.Login.LoginButton));
            Driver.FindElement(Pages.Login.LoginButton).Click();
        }

        public void WaitForLoginPageToNotBeDisplayed()
        {
            Wait.Until(ElementExtensions.InvisibilityOfElement(Pages.Login.LoginButton));
        }

        public bool RequestAnAccountLinkIsDisplayed()
        {
            return Driver.FindElements(Pages.Login.RequestAnAccountLink).Count > 0;
        }

        public void ClickRequestAnAccountLink()
        {
            Driver.FindElement(Pages.Login.RequestAnAccountLink).Click();
        }

        public bool InvalidCredentialsErrorDisplayed()
        {
            return Driver.FindElements(Pages.Login.ErrorSummaryBox).Count > 0;
        }

        public void WaitForErrorSummaryToBeDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.Login.ErrorSummaryBox).Count > 0);
        }

        public void ClickForgotPassword()
        {
            Wait.Until(d => d.FindElements(Pages.Login.ForgotPassword).Count > 0);
            Driver.FindElement(Pages.Login.ForgotPassword).Click();        
        }
    }
}
