using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class ViewUserDetails
    {
        public By PageTitle => CustomBy.DataTestId("view-user-page-title");
        public By OrganisationName => CustomBy.DataTestId("organisation-name");
        public By Name => CustomBy.DataTestId("user-name");
        public By ContactDetails => CustomBy.DataTestId("user-contact-details");
        public By EmailAddress => CustomBy.DataTestId("user-email");
        public By EditUserButton => CustomBy.DataTestId("edit-user-button", "a");
        public By DisableUserButton => CustomBy.DataTestId("change-account-status-button", "button");

    }
}
