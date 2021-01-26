namespace AdminAcceptanceTests.Actions
{
    using AdminAcceptanceTests.Actions.Collections;
    using AdminAcceptanceTests.Actions.Pages;
    using OpenQA.Selenium;

    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
                Homepage = new Homepage(driver),
                Authorization = new Authorization(driver),
                UserAccountsDashboard = new UserAccountsDashboard(driver),
                CreateBuyingOrganisation = new CreateBuyingOrganisation(driver),
                EditOrganisation = new EditOrganisation(driver),
                CreateBuyerUser = new CreateBuyerUser(driver),
                ViewUserDetails = new ViewUserDetails(driver),
                RequestAnAccount = new RequestAnAccount(driver),
                RequestPasswordReset = new RequestPasswordReset(driver),
                SetNewPassword = new SetNewPassword(driver),
                OrganisationDashboard = new OrganisationDashboard(driver),
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
