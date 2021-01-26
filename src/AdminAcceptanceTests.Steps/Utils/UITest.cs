namespace AdminAcceptanceTests.Steps.Utils
{
    using AdminAcceptanceTests.Actions;
    using AdminAcceptanceTests.Actions.Collections;
    using AdminAcceptanceTests.TestData;
    using OpenQA.Selenium;

    public sealed class UITest
    {
        private readonly Settings settings;

        public UITest(Settings settings, BrowserFactory browserFactory)
        {
            this.settings = settings;

            ConnectionString = this.settings.DatabaseSettings.ConnectionString;
            Driver = browserFactory.Driver;
            Pages = new PageActions(Driver).PageActionCollection;
            AdminUser = this.settings.AdminUser;
            Url = this.settings.PBUrl;
        }

        internal string ConnectionString { get; set; }

        internal IWebDriver Driver { get; set; }

        internal PageActionCollection Pages { get; set; }

        internal string Url { get; }

        internal User AdminUser { get; }

        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }
}
