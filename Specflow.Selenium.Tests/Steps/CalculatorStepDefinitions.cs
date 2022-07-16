using FluentAssertions;
using Specflow.Selenium.Tests.PageObject;
using SpecFlow.Actions.Selenium;
using TechTalk.SpecFlow;

namespace Specflow.Selenium.Tests.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly CalculatorPageObject _calculatorPageObject;

        public CalculatorStepDefinitions(IBrowserInteractions browserInteractions)
        {
            _calculatorPageObject = new CalculatorPageObject(browserInteractions);
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculatorPageObject.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculatorPageObject.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _calculatorPageObject.ClickAdd();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            var actualResult = _calculatorPageObject.WaitForNonEmptyResult();

            actualResult.Should().Be(expectedResult.ToString());
        }
    }
}
