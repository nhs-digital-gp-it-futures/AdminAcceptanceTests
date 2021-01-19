using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class EditOrganisation
    {
        public static By PageTitle => CustomBy.DataTestId("edit-org-page-title");
        public static By Save => CustomBy.DataTestId("save-button", "button");
        public static By Confirmation => CustomBy.DataTestId("edit-organisation-confirmation-page-title");
    }
}
