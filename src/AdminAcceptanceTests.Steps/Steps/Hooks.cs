using AdminAcceptanceTests.Steps.Utils;
using AdminAcceptanceTests.TestData;
using System.Collections.Generic;
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
        public void AfterScenario()
        {
            if (Context.ContainsKey("CreatedUser"))
            {
                ((User)Context["CreatedUser"]).Delete(Test.ConnectionString);
            }
            Test.Driver.Quit();
        }
    }
}
