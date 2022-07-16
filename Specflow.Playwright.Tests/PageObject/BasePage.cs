using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.Playwright.Tests.PageObject
{
    public abstract class BasePage
    {
        public readonly Task<IBrowserContext> _browserContext;
        private readonly Task<ITracing> _tracing;
        public readonly Task<IPage> page;

        public Task<ITracing> Tracing => _tracing;
        public BasePage(BrowserDriver browserDriver)
        {
            _browserContext = CreateBrowserContextAsync(browserDriver.Current);
            _tracing = _browserContext.ContinueWith(t => t.Result.Tracing);
            page = CreatePageAsync(browserDriver.Current);
        }

        private async Task<IBrowserContext> CreateBrowserContextAsync(Task<IBrowser> browser)
        {
            return await (await browser).NewContextAsync();
        }

        private async Task<IPage>? CreatePageAsync(Task<IBrowser> browser)
        {
            return await (await browser).NewPageAsync();
        }

        //public abstract string Url { get; }
        //public IPage Page { get; set; }
        //public IBrowser Browser { get; }

        //public async Task NavigateAsync()
        //{
        //    Page = await Browser.NewPageAsync();
        //    await Page.GotoAsync(Url);
        //}

        //public async Task<string> GetPageTitle()
        //{
        //    return await Page.TitleAsync();
        //}
    }
}
