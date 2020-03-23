using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class Authorization : PageAction
    {
        public Authorization(IWebDriver driver) : base(driver)
        {
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(pages.Login.Password).SendKeys(password);
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(pages.Login.Username).SendKeys(username);
        }

        public void Login()
        {
            driver.FindElement(pages.Login.LoginButton).Submit();
        }
    }
}
