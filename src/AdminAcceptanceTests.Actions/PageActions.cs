﻿using AdminAcceptanceTests.Actions.Collections;
using AdminAcceptanceTests.Actions.Pages;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                Homepage = new Homepage(driver),
                Authorization = new Authorization(driver),
                UserAccountsDashboard = new UserAccountsDashboard(driver),
                EditOrganisation = new EditOrganisation(driver),
                CreateBuyerUser = new CreateBuyerUser(driver),
                ViewUserDetails = new ViewUserDetails(driver),
                RequestAnAccount = new RequestAnAccount(driver),
                RequestPasswordReset = new RequestPasswordReset(driver),
                OrganisationDashboard = new Pages.OrganisationDashboard(driver)
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
