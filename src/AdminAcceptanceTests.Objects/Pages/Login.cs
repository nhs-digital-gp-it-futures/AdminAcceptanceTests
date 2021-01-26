namespace AdminAcceptanceTests.Objects.Pages
{
    using AdminAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class Login
    {
        public static By Username => By.Id("EmailAddress");

        public static By Password => By.Id("Password");

        public static By LoginButton => CustomBy.DataTestId("login-submit-button");

        public static By RequestAnAccountLink => CustomBy.DataTestId("request-account-link");

        public static By ErrorSummaryBox => CustomBy.DataTestId("error-summary");

        public static By ForgotPassword => CustomBy.DataTestId("forgot-password-link");
    }
}
