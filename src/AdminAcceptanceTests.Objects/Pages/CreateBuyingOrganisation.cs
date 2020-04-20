using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class CreateBuyingOrganisation
    {
        public By SearchODSPageTitle => CustomBy.DataTestId("find-org-page-title");
        public By ODSCodeField => By.Id("odsCode");
        public By SearchODSButton => CustomBy.DataTestId("continue-button", "button");
        public By SelectOrganisationPageTitle => CustomBy.DataTestId("select-org-page-title");
        public By SelectOrganisationButton => CustomBy.DataTestId("select-org-button", "button");
        public By CreateOrganisationPageTitle => CustomBy.DataTestId("create-org-page-title");
        public By AgreementSignedCheckbox => By.Id("catalogue-agreement-checkbox");
        public By CreateOrganisationButton => CustomBy.DataTestId("save-button", "button");
        public By ConfirmationPage => CustomBy.DataTestId("create-org-confirmation");
        public By OrganisationAlreadyExistsPage => CustomBy.DataTestId("create-org-error-page");
        public By ErrorSummary => CustomBy.DataTestId("error-summary");
    }
}
