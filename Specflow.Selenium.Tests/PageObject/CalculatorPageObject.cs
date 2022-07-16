using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace Specflow.Selenium.Tests.PageObject
{
    public class CalculatorPageObject : CalculatorElementLocators
    {
        //private const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        private readonly IBrowserInteractions _browserInteractions;
        private CalculatorPageObject_Map Map;

        public IWebElement FirstNumber => _browserInteractions.WaitAndReturnElement(FirstNumberFieldLocator);
        public IWebElement SecondNumber => _browserInteractions.WaitAndReturnElement(SecondNumberFieldLocator);
        public IWebElement AddButton => _browserInteractions.WaitAndReturnElement(AddButtonLocator);
        public IWebElement Result => _browserInteractions.WaitAndReturnElement(ResultLabelLocator);
        public IWebElement ResetButton => _browserInteractions.WaitAndReturnElement(ResetButtonLocator);


        public CalculatorPageObject(IBrowserInteractions browserInteractions)
        {
            //Map = new CalculatorPageObject_Map();
            _browserInteractions = browserInteractions;
        }

        public void EnterFirstNumber(string number)
        {
            //Enter text
            FirstNumber.SendKeysWithClear(number);
        }

        public void EnterSecondNumber(string number)
        {
            //Enter text
            SecondNumber.SendKeysWithClear(number);
        }

        public void ClickAdd()
        {
            //Click the add button
            AddButton.ClickWithRetry();
        }

        public void GoToUrl()
        {
            _browserInteractions.GoToUrl(CalculatorUrl);
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            if (_browserInteractions.GetUrl() != CalculatorUrl)
            {
                _browserInteractions.GoToUrl(CalculatorUrl);
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                //Click the rest button
                ResetButton.ClickWithRetry();

                //Wait until the result is empty again
                WaitForEmptyResult();
            }
        }

        public string? WaitForNonEmptyResult()
        {
            //Wait for the result to be not empty
            return _browserInteractions.WaitUntil(
                () => Result.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string? WaitForEmptyResult()
        {
            //Wait for the result to be empty
            return _browserInteractions.WaitUntil(
                () => Result.GetAttribute("value"),
                result => result == string.Empty);
        }
    }
    public class CalculatorPageObject_Map
    {
        //Finding elements by ID
        public By FirstNumberFieldLocator => By.Id("first-number");
        public By SecondNumberFieldLocator => By.Id("second-number");
        public By AddButtonLocator => By.Id("add-button");
        public By ResultLabelLocator => By.Id("result");
        public By ResetButtonLocator => By.Id("reset-button");
    }

}
