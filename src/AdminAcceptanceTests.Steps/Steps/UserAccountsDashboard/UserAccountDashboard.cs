using System;
using System.Collections.Generic;
using System.Text;
using AdminAcceptanceTests.Steps.Utils;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps.UserAccountsDashboard
{
    [Binding]
    public class UserAccountDashboard : TestBase
    {
        public UserAccountDashboard(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [Then(@"there is a button the to edit the Organisation's Account details")]
        public void ThenThereIsAButtonTheToEditTheOrganisationsAccountDetails()
        {
            Test.Pages.UserAccountsDashboard.EditOrganisationButtonDisplayed().Should().BeTrue();
        }

        [Then(@"there is a button to start off the Create User Account journey")]
        public void ThenThereIsAButtonToStartOffTheCreateUserAccountJourney()
        {
            Test.Pages.UserAccountsDashboard.AddUserButtonDisplayed().Should().BeTrue();
        }

        [Then(@"there is a link to edit the User's Account details")]
        public void ThenThereIsALinkToEditTheUsersAccountDetails()
        {
            Test.Pages.UserAccountsDashboard.ViewUserLinksDisplayed().Should().BeTrue();
        }

    }
}
