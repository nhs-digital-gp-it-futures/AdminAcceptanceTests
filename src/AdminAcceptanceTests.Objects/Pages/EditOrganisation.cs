using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class EditOrganisation
    {
        public By PageTitle => CustomBy.DataTestId("edit-org-page-title");
        public By Save => CustomBy.DataTestId("save-button", "button");
        public By Confirmation => CustomBy.DataTestId("edit-organisation-confirmation-page-title");
    }
}
