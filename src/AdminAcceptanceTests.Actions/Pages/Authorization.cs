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
    }
}
