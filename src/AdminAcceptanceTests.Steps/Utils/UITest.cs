using AdminAcceptanceTests.Actions;
using AdminAcceptanceTests.Actions.Collections;
using AdminAcceptanceTests.TestData;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Steps.Utils
{
    public sealed class UITest
    {
        internal string ConnectionString;
        internal IWebDriver Driver;
        internal PageActionCollection Pages;
        internal readonly string Url;
        private readonly Settings _settings;
        internal readonly User AdminUser;

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            _settings = settings;

            ConnectionString = _settings.DatabaseSettings.ConnectionString;
            Driver = browserFactory.Driver;
            Pages = new PageActions(Driver).PageActionCollection;
            AdminUser = _settings.AdminUser;
            Url = _settings.PBUrl;
        }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}