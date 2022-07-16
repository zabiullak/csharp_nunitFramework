using Specflow.Selenium.Tests.PageObject;
using SpecFlow.Actions.Selenium;
using TechTalk.SpecFlow;

namespace Specflow.Selenium.Tests.Hooks
{
    [Binding]
    public class TestHook
    {
        private readonly IBrowserInteractions _browserInteractions;

        public TestHook(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        [BeforeScenario]
        public void BeforeAll()
        {
            var calculatorPageObject = new CalculatorPageObject(_browserInteractions);
            calculatorPageObject.EnsureCalculatorIsOpenAndReset();
        }

        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        //[BeforeScenario("Calculator")]
        //public void BeforeScenario()
        //{
        //    var calculatorPageObject = new CalculatorPageObject(_browserInteractions);
        //    calculatorPageObject.EnsureCalculatorIsOpenAndReset();
        //}
    }
}
