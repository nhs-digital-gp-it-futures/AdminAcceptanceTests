namespace AdminAcceptanceTests.Objects.Pages
{
    using AdminAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class RequestPasswordReset
    {
        public static By Email => CustomBy.DataTestId("input-email-address");

        public static By Submit => CustomBy.DataTestId("submit-button");

        public static By ConfirmationPage => By.XPath("//h1[contains(.,'sent a link')]");
    }
}
