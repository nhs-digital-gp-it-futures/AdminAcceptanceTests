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
            Wait.WaitForJsToComplete();
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyerUser.CreateUser).Count == 1);
            return Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyerUser.Title).Count == 1);
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
            Wait.Until(ElementExtensions.ElementToBeVisible(Objects.Pages.CreateBuyerUser.FirstName));
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.CreateBuyerUser.FirstName));
            Driver.FindElement(Objects.Pages.CreateBuyerUser.FirstName).Click();
            Driver.FindElement(Objects.Pages.CreateBuyerUser.FirstName).Clear();
            Driver.FindElement(Objects.Pages.CreateBuyerUser.FirstName).SendKeys(value);
            if (value != "") {
                Wait.Until(d => d.FindElement(Objects.Pages.CreateBuyerUser.FirstName).GetAttribute("value") == value);
            }
        }
        public void EnterLastName(string value)
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.CreateBuyerUser.LastName));
            Driver.FindElement(Objects.Pages.CreateBuyerUser.LastName).SendKeys(value);
        }
        public void EnterPhoneNumber(string value)
        {
            Driver.FindElement(Objects.Pages.CreateBuyerUser.PhoneNumber).SendKeys(value);
        }
        public void EnterEmailAddress(string value)
        {
            Driver.FindElement(Objects.Pages.CreateBuyerUser.EmailAddress).SendKeys(value);
        }
        public void SubmitUserDetails()
        {
            Wait.Until(ElementExtensions.ElementToBeClickable(Objects.Pages.CreateBuyerUser.CreateUser));
            var element = Driver.FindElement(Objects.Pages.CreateBuyerUser.CreateUser);
            var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            element.Click();
        }

        public string GetConfirmationTitle()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyerUser.ConfirmationTitle).Count > 0);
            return Driver.FindElement(Objects.Pages.CreateBuyerUser.ConfirmationTitle).Text;
        }

        public bool ErrorSummaryDisplayed()
        {
            return Wait.Until(d => d.FindElement(Objects.Pages.CreateBuyerUser.ErrorSummary).Displayed);
        }

        public bool EmailAlreadyExistsErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.EmailAlreadyExists).Count > 0;
        }

        public bool FirstNameRequiredErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.FirstNameRequired).Count > 0;
        }

        public bool LastNameRequiredErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.LastNameRequired).Count > 0;
        }

        public bool EmailRequiredErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.EmailRequired).Count > 0;
        }
        public bool PhoneNumberRequiredErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.PhoneNumberRequired).Count > 0;
        }
        public bool EmailTooLongErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.EmailTooLong).Count > 0;
        }
        public bool FirstNameTooLongErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.FirstNameTooLong).Count > 0;
        }
        public bool LastNameTooLongErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.LastNameTooLong).Count > 0;
        }
        public bool PhoneNumberTooLongErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.PhoneNumberTooLong).Count > 0;
        }

        public bool EmailInvalidFormatErrorDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyerUser.EmailInvalidFormat).Count > 0;
        }
    }
}
