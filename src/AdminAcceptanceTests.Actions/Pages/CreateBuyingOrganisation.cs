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
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyingOrganisation.SearchODSPageTitle).Count > 0);
        }

        public void EnterODSCode(string value)
        {
            Driver.FindElement(Objects.Pages.CreateBuyingOrganisation.ODSCodeField).SendKeys(value);
        }

        public void SearchOrganisation()
        {
            Driver.FindElement(Objects.Pages.CreateBuyingOrganisation.SearchODSButton).Click();
        }

        public void SelectOrganisationPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyingOrganisation.SelectOrganisationPageTitle).Count > 0);
        }

        public void SelectOrganisation()
        {
            Driver.FindElement(Objects.Pages.CreateBuyingOrganisation.SelectOrganisationButton).Click();
        }

        public void CreateOrganisationPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyingOrganisation.CreateOrganisationPageTitle).Count > 0);
        }

        public void CreateOrganisation()
        {
            Driver.FindElement(Objects.Pages.CreateBuyingOrganisation.CreateOrganisationButton).Click();
        }

        public void ConfirmationPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyingOrganisation.ConfirmationPage).Count > 0);
        }

        public void OrganisationAlreadyExistsPageDisplayed()
        {
            Wait.Until(d => d.FindElements(Objects.Pages.CreateBuyingOrganisation.OrganisationAlreadyExistsPage).Count > 0);
        }

        public bool ErrorSummaryDisplayed()
        {
            return Driver.FindElements(Objects.Pages.CreateBuyingOrganisation.ErrorSummary).Count > 0;
        }
    }
}
