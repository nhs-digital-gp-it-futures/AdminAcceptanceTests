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
            Wait.WaitForJsToComplete();
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.Title).Count == 1);
        }

        public void ClickLoginButton()
        {
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.LoginLogoutLink).Count == 1);
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.Homepage.LoginLogoutLink));
            Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Click();
        }

        public bool LoginLogoutLinkText(string expectedValue)
        {
            Wait.WaitForJsToComplete();
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.LoginLogoutLink).Count == 1);
            return Driver.FindElement(Objects.Pages.Homepage.LoginLogoutLink).Text.Contains(expectedValue, StringComparison.OrdinalIgnoreCase);
        }

        public void WaitUntilLoggedInFully()
        {
            PageDisplayed();
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.LoginLogoutLink).Count == 1);            
            Wait.Until(s => LoginLogoutLinkText("Log Out"));
        }

        public void WaitUntilLoggedOutFully()
        {
            PageDisplayed();
            Wait.Until(s => s.FindElements(Objects.Pages.Homepage.LoginLogoutLink).Count == 1);
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
            return Driver.FindElements(Objects.Pages.Homepage.AdminTile).Count == 1;
        }

        public void ClickAdminTile()
        {
            Thread.Sleep(500);
            Wait.WaitForJsToComplete();
            Wait.Until(d => d.FindElements(Objects.Pages.Homepage.AdminTile).Count == 1);
            Wait.Until(ElementExtensions.ElementToBeVisible(Objects.Pages.Homepage.AdminTile));
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.Homepage.AdminTile));
            Driver.FindElement(Objects.Pages.Homepage.AdminTile).Click();
            Wait.Until(d => d.FindElements(Objects.Pages.Homepage.AdminTile).Count == 0);
        }
    }
}
