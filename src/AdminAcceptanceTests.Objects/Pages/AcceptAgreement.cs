

using AdminAcceptanceTests.Objects.Utils;
using OpenQA.Selenium;

namespace AdminAcceptanceTests.Objects.Pages
{
    public class AcceptAgreement
    {
        public By SubmitButton => CustomBy.DataTestId("agreement-submit-button");
        public By Checkbox => CustomBy.DataTestId("agree-terms-checkbox");
        public By ErrorSummary => CustomBy.DataTestId("error-summary");
    }
}
