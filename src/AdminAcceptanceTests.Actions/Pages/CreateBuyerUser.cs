using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class CreateBuyerUser : PageAction
    {
        public CreateBuyerUser(IWebDriver driver) : base(driver)
        {

        }

        public bool PageDisplayed()
        {
            Driver.WaitForJsToComplete(Wait);
            Wait.Until(d => d.FindElements(Pages.CreateBuyerUser.CreateUser).Count == 1);
            return Wait.Until(d => d.FindElements(Pages.CreateBuyerUser.Title).Count == 1);
        }

        public void CompleteForm(User user)
        {
            Thread.Sleep(500);
            PageDisplayed();
            EnterFirstName(user.FirstName);
            EnterLastName(user.LastName);
            EnterPhoneNumber(user.PhoneNumber);
            EnterEmailAddress(user.Email);
        }

        public void EnterFirstName(string value)
        {
            Wait.Until(ElementExtensions.ElementToBeVisible(Pages.CreateBuyerUser.FirstName));
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.CreateBuyerUser.FirstName));
            Driver.FindElement(Pages.CreateBuyerUser.FirstName).Click();
            Driver.FindElement(Pages.CreateBuyerUser.FirstName).Clear();
            Driver.FindElement(Pages.CreateBuyerUser.FirstName).SendKeys(value);
            Wait.Until(d => d.FindElement(Pages.CreateBuyerUser.FirstName).GetAttribute("value") != "");
        }
        public void EnterLastName(string value)
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.CreateBuyerUser.LastName));
            Driver.FindElement(Pages.CreateBuyerUser.LastName).SendKeys(value);
        }
        public void EnterPhoneNumber(string value)
        {
            Driver.FindElement(Pages.CreateBuyerUser.PhoneNumber).SendKeys(value);
        }
        public void EnterEmailAddress(string value)
        {
            Driver.FindElement(Pages.CreateBuyerUser.EmailAddress).SendKeys(value);
        }
        public void SubmitUserDetails()
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Pages.CreateBuyerUser.CreateUser));
            var element = Driver.FindElement(Pages.CreateBuyerUser.CreateUser);
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
        }

        public string GetConfirmationTitle()
        {
            Wait.Until(d => d.FindElements(Pages.CreateBuyerUser.ConfirmationTitle).Count > 0);
            return Driver.FindElement(Pages.CreateBuyerUser.ConfirmationTitle).Text;
        }

        public bool ErrorSummaryDisplayed()
        {
            return Wait.Until(d => d.FindElement(Pages.CreateBuyerUser.ErrorSummary).Displayed);
        }

        public bool EmailAlreadyExistsErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.EmailAlreadyExists).Count > 0;
        }

        public bool FirstNameRequiredErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.FirstNameRequired).Count > 0;
        }

        public bool LastNameRequiredErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.LastNameRequired).Count > 0;
        }

        public bool EmailRequiredErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.EmailRequired).Count > 0;
        }
        public bool PhoneNumberRequiredErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.PhoneNumberRequired).Count > 0;
        }
        public bool EmailTooLongErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.EmailTooLong).Count > 0;
        }
        public bool FirstNameTooLongErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.FirstNameTooLong).Count > 0;
        }
        public bool LastNameTooLongErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.LastNameTooLong).Count > 0;
        }
        public bool PhoneNumberTooLongErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.PhoneNumberTooLong).Count > 0;
        }

        public bool EmailInvalidFormatErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.EmailInvalidFormat).Count > 0;
        }
    }
}
