using AdminAcceptanceTests.Actions;
using AdminAcceptanceTests.Actions.Collections;
using AdminAcceptanceTests.TestData;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Steps.Utils
{
    public sealed class UITest
    {
        internal string ConnectionString { get; set; }
        internal IWebDriver Driver { get; set; }
        internal PageActionCollection Pages { get; set; }
        internal readonly string Url { get; set; }        
        internal readonly User AdminUser { get; set; }

        private readonly Settings _settings;

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