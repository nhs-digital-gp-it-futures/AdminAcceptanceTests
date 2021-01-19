using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class RequestPasswordReset
    {
        public static By Email => CustomBy.DataTestId("input-email-address");
        public static By Submit => CustomBy.DataTestId("submit-button");
        public static By ConfirmationPage => By.XPath("//h1[contains(.,'sent a link')]");
    }
}
