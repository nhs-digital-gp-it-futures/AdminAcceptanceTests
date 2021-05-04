namespace AdminAcceptanceTests.Objects.Pages
{
    using AdminAcceptanceTests.Objects.Utils;
    using OpenQA.Selenium;

    public static class UserAccountsDashboard
    {
        public static By OrganisationName => CustomBy.DataTestId("org-page-title");

        public static By ODSCode => CustomBy.DataTestId("org-page-ods-code");

        public static By EditOrganisation => CustomBy.DataTestId("edit-org-button", "a");

        public static By AddUser => CustomBy.DataTestId("add-user-button", "a");

        public static By ViewUserLinks => CustomBy.DataTestId("user-table", "a");

        public static By UserTable => CustomBy.DataTestId("user-table");

        public static By RelatedTable => By.Id("related-org-table");

        public static By DisabledAccountFlag => By.CssSelector("[data-test-id^=account-disabled-tag]");

        public static By UserNameLink => By.CssSelector("[data-test-id^=user-name]");

        public static By AddAnOrganisationButton => CustomBy.DataTestId("add-organisation-button", "a");

        public static By RadioButton => By.ClassName("nhsuk-radios__input");

        public static By RadioButtonLabel => By.CssSelector("div.nhsuk-radios__item label.nhsuk-radios__label");

        public static By ConfirmButton => CustomBy.DataTestId("submit-button", "button");

        public static By ErrorMessages => By.CssSelector("ul.nhsuk-list.nhsuk-error-summary__list li a");

        public static By BackLink => CustomBy.DataTestId("go-back-link");

        public static By TableRows => By.CssSelector("[data-test-id^=table-row-]");

        public static By RelatedOdsCodes => By.CssSelector("[data-test-id^= related-org-odsCode-]");

        public static By RemoveButton => CustomBy.DataTestId("submit-button");

        public static By RemoveLinkStart => By.CssSelector("[data-test-id^= related-org-remove-]");

        public static By CancelLink => By.LinkText("Cancel");

        public static By RemoveLink(string orgId) => CustomBy.DataTestId($"related-org-remove-{orgId.ToLower()}");

        public static By RelatedOrgName(string orgId) => CustomBy.DataTestId($"related-org-name-{orgId.ToLower()}");
    }
}
