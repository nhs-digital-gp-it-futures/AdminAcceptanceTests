using AdminAcceptanceTests.Actions;
using AdminAcceptanceTests.Actions.Collections;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Steps.Utils
{
    public sealed class UITest
    {
        internal string ConnectionString;
        internal IWebDriver Driver;
        internal string ExpectedSectionLinkInErrorMessage;
        internal PageActionCollection Pages;
        internal readonly string url;

        public UITest()
        {
            ConnectionString = EnvironmentVariables.DbConnectionString();

            Driver = new BrowserFactory().Driver;
            Pages = new PageActions(Driver).PageActionCollection;
            url = EnvironmentVariables.Url();

            GoToUrl();
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}