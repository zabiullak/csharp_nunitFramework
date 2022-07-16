using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Specflow.Selenium.Tests.PageObject
{
    public class CalculatorElementLocators
    {
        private protected const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        //Finding elements by ID
        private protected By FirstNumberFieldLocator => By.Id("first-number");
        private protected By SecondNumberFieldLocator => By.Id("second-number");
        private protected By AddButtonLocator => By.Id("add-button");
        private protected By ResultLabelLocator => By.Id("result");
        private protected By ResetButtonLocator => By.Id("reset-button");
    }
}
