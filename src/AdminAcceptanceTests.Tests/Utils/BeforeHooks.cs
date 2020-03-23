using AdminAcceptanceTests.Steps.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AdminAcceptanceTests.Tests.Utils
{
    [Binding]
    public sealed class BeforeHook : TestBase
    {
        public BeforeHook(UITest test, ScenarioContext context) : base(test, context)
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test.GoToUrl();
        }
    }
}
