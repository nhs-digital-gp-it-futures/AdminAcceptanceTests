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
        public By Password1 => CustomBy.DataTestId("");
        public By Password2 => CustomBy.DataTestId("");
        public By Submit => CustomBy.DataTestId("");
        public By Confirmation => CustomBy.DataTestId("");
        public By Error => CustomBy.DataTestId("");
    }
}
