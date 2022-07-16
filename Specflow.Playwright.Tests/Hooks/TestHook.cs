using Microsoft.Playwright;
using Specflow.Playwright.Tests.PageObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow.Playwright.Tests.Hooks
{
    [Binding]
    public sealed class TestHook
    {
        private readonly string _traceName;

        public TestHook(ScenarioContext scenarioContext)
        {
            _traceName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        [BeforeScenario]
        public async Task BeforeScenarioAsync(CalculatorPage page)
        {
            await page.EnsureCalculatorIsOpenAndResetAsync();
        }

        [BeforeScenario]
        public async Task StartTracingAsync(CalculatorPage calculatorPageObject)
        {
            var tracing = await calculatorPageObject.Tracing;
            await tracing.StartAsync(new TracingStartOptions
            {
                Name = _traceName,
                Screenshots = true,
                Snapshots = true
            });
        }

        [AfterScenario]
        public async Task StopTracingAsync(CalculatorPage calculatorPageObject)
        {
            var tracing = await calculatorPageObject.Tracing;
            await tracing.StopAsync(new TracingStopOptions()
            {
                Path = $"traces/{_traceName}.zip"
            });
        }

        //[BeforeScenario]
        //public async void BeforeScenarioWithTag(IObjectContainer container)
        //{
        //    var playwright = await Playwright.CreateAsync();
        //    var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //    {
        //        Headless = false,
        //        SlowMo = 2000
        //    });
        //    var pageObject = new GooglePage(browser);
        //    container.RegisterInstanceAs(playwright);
        //    container.RegisterInstanceAs(browser);
        //    container.RegisterInstanceAs(pageObject);
        //}

        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        //[AfterScenario]
        //public async void AfterScenario(IObjectContainer container)
        //{
        //    var browser = container.Resolve<IBrowser>();
        //    await browser.CloseAsync();
        //    var playwright = container.Resolve<IPlaywright>();
        //    playwright.Dispose();
        //}


    }
}
