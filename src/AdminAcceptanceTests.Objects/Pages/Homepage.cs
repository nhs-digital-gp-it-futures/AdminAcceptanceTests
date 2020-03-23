using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class Homepage
    {
        public By Title => By.CssSelector(".nhsuk-hero__wrapper h1");
        public By LoginLogoutLink => CustomBy.DataTestId("login-logout-component", "a");
    }
}
