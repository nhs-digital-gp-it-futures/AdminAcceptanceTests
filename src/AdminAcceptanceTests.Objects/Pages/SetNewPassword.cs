using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class SetNewPassword
    {
        public By PageTitle => By.XPath("//h1[contains(.,'Choose your password')]");
        public By Password1 => CustomBy.DataTestId("input-reset-password");
        public By Password2 => CustomBy.DataTestId("input-confirm-reset-password");
        public By Submit => CustomBy.DataTestId("reset-password-button");
        public By Confirmation => By.XPath("//h1[contains(.,'Password set')]");
        public By Error => CustomBy.DataTestId("error-summary");
        public By GoToLoginLink => CustomBy.DataTestId("go-back-link", "a");
    }
}
