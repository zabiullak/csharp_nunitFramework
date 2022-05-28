using System;
using Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace FreeCodeCamp.Feature
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;
        private ChromeOptions options = new ChromeOptions();

        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            //We use the Chrome browser
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            //var chromeDriverService = ChromeDriverService.CreateDefaultService();

            //var chromeOptions = new ChromeOptions();

            var chromeDriver = new ChromeDriver(AddChromeOptions());

            return chromeDriver;
        }
        public ChromeOptions AddChromeOptions()
        {
            //FW.Log.Info("Launching google chrome with new profile..");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-notifications");
            //options.AddUserProfilePreference("download.default_directory", _autoUtils.GetRepoDownloadFolder());
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("no-sandbox");
            options.AddArguments("enable-features=NetworkServiceInProcess");
            options.AddArguments("disable-features=NetworkService");
            return options;
        }
        /// <summary>
        /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}