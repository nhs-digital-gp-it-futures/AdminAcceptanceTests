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
            Driver.FindElement(Pages.Login.Password).SendKeys(password);
        }

        public void EnterUsername(string username)
        {
            Driver.FindElement(Pages.Login.Username).SendKeys(username);
        }

        public void Login()
        {
            Driver.FindElement(Pages.Login.LoginButton).Submit();
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
