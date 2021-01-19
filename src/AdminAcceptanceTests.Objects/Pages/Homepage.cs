using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public static class Homepage
    {
        public static By Title => By.CssSelector(".nhsuk-hero__wrapper h1");
        public static By LoginLogoutLink => CustomBy.DataTestId("login-logout-component", "a");
        public static By LoggedInDisplayName => CustomBy.DataTestId("login-logout-component", "span");
        public static By AdminTile => CustomBy.DataTestId("admin-promo", "a");
    }
}
