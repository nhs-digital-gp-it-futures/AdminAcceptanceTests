using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Steps.Steps
{
    [Binding]
    public sealed class Hooks : TestBase
    {
        public Hooks(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (Context.ContainsKey("CreatedUser"))
            {
                ((User)Context["CreatedUser"]).Delete(Test.ConnectionString);
            }
            if (Context.ContainsKey("Email"))
            {
                await EmailServerDriver.ClearEmailAsync(Test.Url, ((Email)Context["Email"]).Id);
            }
            if (Context.ContainsKey("CreatedOrganisation"))
            {
                ((Organisation)Context["CreatedOrganisation"]).Delete(Test.ConnectionString);
            }
            if (Context.ContainsKey("DeletedOrganisation"))
            {
                ((Organisation)Context["DeletedOrganisation"]).Create(Test.ConnectionString);
            }            
            Test.Driver.Quit();
        }
    }
}
