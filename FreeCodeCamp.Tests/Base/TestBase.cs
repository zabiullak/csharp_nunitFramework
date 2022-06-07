using Applitools;
using Applitools.Selenium;
using Framework;
using Framework.Selenium;
using Framework.Utilities.Applitools;
using FreeCodeCamp.WebPages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            HrmApp.Init();
            //Driver.Goto(FW.Config.Test.Url);
            ApplitoolsEyes.Init();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Passed)
            {
                FW.Log.Info("Outcome: Passed");
            }
            else if(outcome == TestStatus.Failed)
            {
                Driver.TakeScreenShot("test_Failed");
                FW.Log.Info("Outcome: Failed");
            }
            else
            {
                FW.Log.Warning("Outcome: " + outcome);
            }
            Driver.Quit();

            ApplitoolsEyes.TearDownEyes();
        }



        
    }
}
