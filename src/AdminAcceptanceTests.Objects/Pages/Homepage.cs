using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class Homepage
    {
        public By Title => By.CssSelector(".nhsuk-hero__wrapper h1");
        public By LoginLogoutLink => CustomBy.DataTestId("login-logout-component", "a");
        public By LoggedInDisplayName => CustomBy.DataTestId("login-logout-component", "span");
        public By AdminTile => CustomBy.DataTestId("admin-promo", "a");
    }
}
