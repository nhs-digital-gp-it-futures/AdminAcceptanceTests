using AdminAcceptanceTests.Actions.Utils;
using FluentAssertions;
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
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count > 0);
            Driver.FindElement(Pages.Homepage.LoginLogoutLink).Click();
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count == 0);
        }

        public bool LoginLogoutLinkText(string expectedValue)
        {
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count == 1);
            Wait.Until(s => s.FindElement(Pages.Homepage.LoginLogoutLink).Text.Contains(expectedValue, StringComparison.OrdinalIgnoreCase));
            return true;
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText("Log out"))
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
            Wait.Until(d => d.FindElements(Pages.Homepage.AdminTile).Count == 1);
            Driver.FindElement(Pages.Homepage.AdminTile).Click();
            Wait.Until(d => d.FindElements(Pages.Homepage.AdminTile).Count == 0);
        }
    }
}
