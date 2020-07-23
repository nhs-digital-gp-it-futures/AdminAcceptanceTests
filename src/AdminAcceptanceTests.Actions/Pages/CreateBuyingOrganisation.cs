using AdminAcceptanceTests.Actions.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions.Pages
{
    public sealed class CreateBuyingOrganisation : PageAction
    {
        public CreateBuyingOrganisation(IWebDriver driver) : base(driver)
        {

        }

        public void SearchPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.CreateBuyingOrganisation.SearchODSPageTitle).Count > 0);
        }

        public void EnterODSCode(string value)
        {
            Driver.FindElement(Pages.CreateBuyingOrganisation.ODSCodeField).SendKeys(value);
        }

        public void SearchOrganisation()
        {
            Driver.FindElement(Pages.CreateBuyingOrganisation.SearchODSButton).Click();
        }

        public void SelectOrganisationPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.CreateBuyingOrganisation.SelectOrganisationPageTitle).Count > 0);
        }

        public void SelectOrganisation()
        {
            Driver.FindElement(Pages.CreateBuyingOrganisation.SelectOrganisationButton).Click();
        }

        public void CreateOrganisationPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.CreateBuyingOrganisation.CreateOrganisationPageTitle).Count > 0);
        }

        public void CreateOrganisation()
        {
            Driver.FindElement(Pages.CreateBuyingOrganisation.CreateOrganisationButton).Click();
        }

        public void ConfirmationPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.CreateBuyingOrganisation.ConfirmationPage).Count > 0);
        }

        public void OrganisationAlreadyExistsPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Pages.CreateBuyingOrganisation.OrganisationAlreadyExistsPage).Count > 0);
        }

        public bool ErrorSummaryDisplayed()
        {
            return Driver.FindElements(Pages.CreateBuyingOrganisation.ErrorSummary).Count > 0;
        }
    }
}
