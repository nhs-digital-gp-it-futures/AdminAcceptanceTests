using AdminAcceptanceTests.Actions.Collections;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                Homepage = new Pages.Homepage(driver),
                Authorization = new Pages.Authorization(driver),
                OrganisationDashboard = new Pages.OrganisationDashboard(driver)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
