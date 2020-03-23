using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class Homepage : PageAction
    {
        public Homepage(IWebDriver driver) : base(driver)
        {
        }
        public void PageDisplayed()
        {
            wait.Until(s => s.FindElement(pages.Homepage.Title).Displayed);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(pages.Homepage.LoginLogoutLink).Click();
        }

        public string LoginLogoutLinkText()
        {
            wait.Until(s => s.FindElement(pages.Homepage.LoginLogoutLink).Displayed);
            return driver.FindElement(pages.Homepage.LoginLogoutLink).Text;
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText().Equals("Log out", StringComparison.OrdinalIgnoreCase))
            {
                driver.FindElement(pages.Homepage.LoginLogoutLink).Click();
            }
            else
            {
                throw new WebDriverException("Log out text incorrect");
            }
        }

        public bool AdminTileIsDisplayed()
        {
            return driver.FindElements(pages.Homepage.AdminTile).Count > 0;
        }

        public void ClickAdminTile()
        {
            driver.FindElement(pages.Homepage.AdminTile).Click();
        }
    }
}
