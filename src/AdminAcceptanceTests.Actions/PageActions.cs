using AdminAcceptanceTests.Actions.Collections;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminAcceptanceTests.Actions
{
    public sealed class PageActions
    {
        public PageActions(IWebDriver driver)
        {
            PageActionCollection = new PageActionCollection
            {
            };
        }

        public PageActionCollection PageActionCollection { get; set; }
    }
}
