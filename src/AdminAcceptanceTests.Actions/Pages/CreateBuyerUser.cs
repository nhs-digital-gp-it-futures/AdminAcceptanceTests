﻿using AdminAcceptanceTests.Actions.Utils;
using AdminAcceptanceTests.TestData;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class CreateBuyerUser : PageAction
    {
        public CreateBuyerUser(IWebDriver driver) : base(driver)
        {

        }

        public bool PageDisplayed()
        {
            return Wait.Until(d => d.FindElement(Pages.CreateBuyerUser.Title).Displayed);
        }

        public void CompleteForm(User user)
        {
            EnterFirstName(user.FirstName);
            EnterLastName(user.LastName);
            EnterPhoneNumber(user.PhoneNumber);
            EnterEmailAddress(user.Email);
        }

        public void EnterFirstName(string value)
        {
            Driver.FindElement(Pages.CreateBuyerUser.FirstName).SendKeys(value);
        }
        public void EnterLastName(string value)
        {
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
            Driver.FindElement(Pages.CreateBuyerUser.CreateUser).Click();
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

        public bool EmailInvalidFormatErrorDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyerUser.EmailInvalidFormat).Count > 0;
        }
    }
}