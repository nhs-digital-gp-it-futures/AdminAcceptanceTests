namespace AdminAcceptanceTests.Steps.Utils
{
    using TechTalk.SpecFlow;

    public abstract class TestBase
    {
        internal readonly ScenarioContext Context;
        internal readonly UITest Test;

        protected TestBase(UITest test, ScenarioContext context)
        {
            Test = test;
            Context = context;
        }
    }
}