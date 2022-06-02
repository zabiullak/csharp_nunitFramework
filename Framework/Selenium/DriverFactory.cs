using Framework.Utilities.Listeners;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        static ChromeOptions options = new ChromeOptions();

        public static IWebDriver Build(string browserName)
        {
            FW.Log.Info($"Browser: {browserName}");

            switch (browserName)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    //return new ChromeDriver(FW.WORKSPACE_DIRECTORY + "_drivers");
                    //IWebDriver _driver =  new ChromeDriver(AddChromeOptions());
                    return new ChromeDriver(AddChromeOptions());
                    //WebListener webListener = new WebListener(_driver);
                    //return webListener.Driver;

                case "firefox":
                    return new FirefoxDriver();

                default:
                    throw new System.ArgumentException($"{browserName} not supported.");
            }
        }

        public static ChromeOptions AddChromeOptions()
        {
            FW.Log.Info("Launching google chrome with new profile..");
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
    }
}
