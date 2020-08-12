﻿using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public sealed class Login
    {
        public By Username => By.Id("EmailAddress");
        public By Password => By.Id("Password");
        public By LoginButton => CustomBy.DataTestId("login-submit-button");
        public By RequestAnAccountLink => CustomBy.DataTestId("request-account-link");
        public By ErrorSummaryBox => CustomBy.DataTestId("error-summary");
        public By ForgotPassword => CustomBy.DataTestId("forgot-password-link");
    }
}
