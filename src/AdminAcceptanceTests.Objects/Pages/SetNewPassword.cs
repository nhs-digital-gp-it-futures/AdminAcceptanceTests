namespace AdminAcceptanceTests.Objects.Pages
{
    using AdminAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class SetNewPassword
    {
        public static By PageTitle => By.XPath("//h1[contains(.,'Choose your password')]");

        public static By Password1 => CustomBy.DataTestId("input-reset-password");

        public static By Password2 => CustomBy.DataTestId("input-confirm-reset-password");

        public static By Submit => CustomBy.DataTestId("reset-password-button");

        public static By Confirmation => By.XPath("//h1[contains(.,'Password set')]");

        public static By Error => CustomBy.DataTestId("error-summary");

        public static By GoToLoginLink => CustomBy.DataTestId("go-back-link");
    }
}
