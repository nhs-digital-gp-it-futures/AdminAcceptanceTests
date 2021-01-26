namespace AdminAcceptanceTests.Actions.Pages
{
    using AdminAcceptanceTests.Actions.Utils;
    using OpenQA.Selenium;

    public sealed class RequestAnAccount : PageAction
    {
        public RequestAnAccount(IWebDriver driver)
            : base(driver)
        {
        }

        public bool PageDisplayed()
        {
            return Driver.FindElements(Objects.Pages.RequestAnAccount.RequestAnAccountButton).Count > 0;
        }

        public string GetRequestAnAccountButtonMailToValue()
        {
            return Driver.FindElement(Objects.Pages.RequestAnAccount.RequestAnAccountButton).GetAttribute("href");
        }
    }
}
