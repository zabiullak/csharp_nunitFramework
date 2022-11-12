using BoDi;
using Microsoft.Playwright;
using Playwright_tool_with_specflow.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Playwright_tool_with_specflow.Hooks
{
    [Binding]
    public class Hook
    {
        public IBrowser browser;
        public IBrowserContext context;
        public IPage page;
        public IPlaywright playwright;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hook(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            if (_scenarioContext.TestError != null)
            {
                await Helper.Screenshot(page);
            }
            await browser.DisposeAsync();
        }

        [BeforeScenario()]
        public async Task createBrowser()
        {
            playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions typeLaunchOptions = new BrowserTypeLaunchOptions { Headless = false };
            browser = await playwright.Chromium.LaunchAsync(typeLaunchOptions);
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(page);
        }
    }
}
