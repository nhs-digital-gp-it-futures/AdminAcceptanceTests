﻿namespace AdminAcceptanceTests.Steps.Steps
{
    using System.Threading.Tasks;
    using AdminAcceptanceTests.Actions.Utils;
    using AdminAcceptanceTests.Steps.Utils;
    using AdminAcceptanceTests.TestData;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Hooks : TestBase
    {
        public Hooks(UITest test, ScenarioContext context)
            : base(test, context)
        {
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            Test.GoToUrl();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (Context.ContainsKey("CreatedUser"))
            {
                await ((User)Context["CreatedUser"]).Delete(Test.ConnectionString);
            }

            if (Context.ContainsKey("Email"))
            {
                await EmailServerDriver.ClearEmailAsync(Test.Url, ((Email)Context["Email"]).Id);
            }

            if (Context.ContainsKey("CreatedOrganisation"))
            {
                await ((Organisation)Context["CreatedOrganisation"]).Delete(Test.ConnectionString);
            }

            if (Context.ContainsKey("DeletedOrganisation"))
            {
                await ((Organisation)Context["DeletedOrganisation"]).Create(Test.ConnectionString);
            }

            Test.Driver.Quit();
        }
    }
}
