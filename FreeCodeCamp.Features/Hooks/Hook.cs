using Framework;
using Framework.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FreeCodeCamp.WebPages;

namespace FreeCodeCamp.Features.Hooks
{
    [Binding]
    public class Hook
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            FW.SetConfig();
            FW.CreateTestResultDirectory();
        }
        
        [BeforeScenario]
        public static void BeforeScenario()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
