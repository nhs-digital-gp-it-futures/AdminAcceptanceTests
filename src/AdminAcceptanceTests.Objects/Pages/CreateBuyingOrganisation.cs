using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class CreateBuyingOrganisation
    {
        public static By SearchODSPageTitle => CustomBy.DataTestId("find-org-page-title");
        public static By ODSCodeField => By.Id("odsCode");
        public static By SearchODSButton => CustomBy.DataTestId("continue-button", "button");
        public static By SelectOrganisationPageTitle => CustomBy.DataTestId("select-org-page-title");
        public static By SelectOrganisationButton => CustomBy.DataTestId("select-org-button", "button");
        public static By CreateOrganisationPageTitle => CustomBy.DataTestId("create-org-page-title");
        public static By CreateOrganisationButton => CustomBy.DataTestId("save-button", "button");
        public static By ConfirmationPage => CustomBy.DataTestId("create-org-confirmation-page");
        public static By OrganisationAlreadyExistsPage => CustomBy.DataTestId("create-org-error-page");
        public static By ErrorSummary => CustomBy.DataTestId("error-summary");
    }
}
