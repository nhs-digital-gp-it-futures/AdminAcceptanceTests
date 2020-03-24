using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class Homepage : PageAction
    {
        public Homepage(IWebDriver driver) : base(driver)
        {
        }
        public void PageDisplayed()
        {
            Wait.Until(s => s.FindElement(Pages.Homepage.Title).Displayed);
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(Pages.Homepage.LoginLogoutLink).Click();
        }

        public string LoginLogoutLinkText()
        {
            Wait.Until(s => s.FindElement(Pages.Homepage.LoginLogoutLink).Displayed);
            return Driver.FindElement(Pages.Homepage.LoginLogoutLink).Text;
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText().Equals("Log out", StringComparison.OrdinalIgnoreCase))
            {
                Driver.FindElement(Pages.Homepage.LoginLogoutLink).Click();
            }
            else
            {
                throw new WebDriverException("Log out text incorrect");
            }
        }

        public bool AdminTileIsDisplayed()
        {
            return Driver.FindElements(Pages.Homepage.AdminTile).Count > 0;
        }

        public void ClickAdminTile()
        {
            Driver.FindElement(Pages.Homepage.AdminTile).Click();
        }
    }
}
