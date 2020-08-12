using AdminAcceptanceTests.Actions.Utils;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class Homepage : PageAction
    {
        public Homepage(IWebDriver driver) : base(driver)
        {
        }
        public void PageDisplayed()
        {
            Driver.WaitForJsToComplete(Wait);
            Wait.Until(s => s.FindElements(Pages.Homepage.Title).Count == 1);
        }

        public void ClickLoginButton()
        {
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count == 1);
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.Homepage.LoginLogoutLink));
            Driver.FindElement(Pages.Homepage.LoginLogoutLink).Click();
        }

        public bool LoginLogoutLinkText(string expectedValue)
        {
            Driver.WaitForJsToComplete(Wait);
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count == 1);
            return Driver.FindElement(Pages.Homepage.LoginLogoutLink).Text.Contains(expectedValue, StringComparison.OrdinalIgnoreCase);
        }

        public void WaitUntilLoggedInFully()
        {
            PageDisplayed();
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count == 1);            
            Wait.Until(s => LoginLogoutLinkText("Log Out"));
        }

        public void WaitUntilLoggedOutFully()
        {
            PageDisplayed();
            Wait.Until(s => s.FindElements(Pages.Homepage.LoginLogoutLink).Count == 1);
            Wait.Until(s => LoginLogoutLinkText("Log in"));
        }

        public void LogOut()
        {
            if (LoginLogoutLinkText("Log out"))
            {
                ClickLoginButton();
            }
            else
            {
                throw new WebDriverException("Log out text incorrect");
            }
        }

        public bool AdminTileIsDisplayed()
        {
            return Driver.FindElements(Pages.Homepage.AdminTile).Count == 1;
        }

        public void ClickAdminTile()
        {
            Thread.Sleep(500);
            Driver.WaitForJsToComplete(Wait);
            Wait.Until(d => d.FindElements(Pages.Homepage.AdminTile).Count == 1);
            Wait.Until(ElementExtensions.ElementToBeVisible(Pages.Homepage.AdminTile));
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.Homepage.AdminTile));
            Driver.FindElement(Pages.Homepage.AdminTile).Click();
            Wait.Until(d => d.FindElements(Pages.Homepage.AdminTile).Count == 0);
        }
    }
}
