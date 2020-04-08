using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class RequestPasswordReset
    {
        public By Email => CustomBy.DataTestId("input-email-address");
        public By Submit => CustomBy.DataTestId("submit-button");
        public By ConfirmationPage => By.XPath("//h1[contains(.,'sent a link')]");
    }
}
