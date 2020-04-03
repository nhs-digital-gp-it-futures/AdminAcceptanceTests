using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class EditOrganisation
    {
        public By PageTitle => CustomBy.DataTestId("edit-org-page-title");
        public By CatalogueAgreement => By.Id("catalogue-agreement-checkbox");
        public By Save => CustomBy.DataTestId("save-button", "button");
        public By Confirmation => CustomBy.DataTestId("edit-org-confirmation-page-title");
    }
}
