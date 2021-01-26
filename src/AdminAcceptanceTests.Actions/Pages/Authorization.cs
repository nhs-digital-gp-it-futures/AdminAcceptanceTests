namespace AdminAcceptanceTests.Actions.Pages
{
    using AdminAcceptanceTests.Actions.Utils;
    using OpenQA.Selenium;

    public sealed class Authorization : PageAction
    {
        public Authorization(IWebDriver driver)
            : base(driver)
        {
        }

        public void EnterPassword(string password)
        {
            Driver.FindElement(Objects.Pages.Login.Password).Click();
            Driver.FindElement(Objects.Pages.Login.Password).SendKeys(password);
            Wait.Until(d => d.FindElement(Objects.Pages.Login.Password).GetAttribute("value") != string.Empty);
        }

        public void EnterUsername(string username)
        {
            Wait.WaitForJsToComplete();
            Wait.Until(d => d.FindElements(Objects.Pages.Login.Username).Count == 1);
            Wait.Until(d => d.FindElement(Objects.Pages.Login.Username).GetAttribute("value") == string.Empty);
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.Login.Username));
            Driver.FindElement(Objects.Pages.Login.Username).Click();
            Driver.FindElement(Objects.Pages.Login.Username).SendKeys(username);
            Wait.Until(d => d.FindElement(Objects.Pages.Login.Username).GetAttribute("value") != string.Empty);
        }

        public void Login()
        {
            Wait.WaitForJsToComplete();
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.Login.LoginButton));
            Driver.FindElement(Objects.Pages.Login.LoginButton).Click();
        }

        public void WaitForLoginPageToNotBeDisplayed()
        {
            Wait.WaitForJsToComplete();
            Wait.Until(ElementExtensions.InvisibilityOfElement(Objects.Pages.Login.LoginButton));
        }

        public bool RequestAnAccountLinkIsDisplayed()
        {
            return Driver.FindElements(Objects.Pages.Login.RequestAnAccountLink).Count > 0;
        }

        public void ClickRequestAnAccountLink()
        {
            Driver.FindElement(Objects.Pages.Login.RequestAnAccountLink).Click();
        }

        public bool InvalidCredentialsErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.Login.ErrorSummaryBox).Count > 0;
        }

        public void WaitForErrorSummaryToBeDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.Login.ErrorSummaryBox).Count > 0);
        }

        public void ClickForgotPassword()
        {
            Wait.WaitForJsToComplete();
            Wait.Until(d => d.FindElements(Objects.Pages.Login.ForgotPassword).Count > 0);
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.Login.ForgotPassword));
            Driver.FindElement(Objects.Pages.Login.ForgotPassword).Click();
        }
    }
}
