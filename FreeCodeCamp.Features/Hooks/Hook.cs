using Framework;
using Framework.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FreeCodeCamp.WebPages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using AventStack.ExtentReports.Gherkin.Model;
using System.IO;
using NUnit.Framework;
using System.Collections.Concurrent;
using OpenQA.Selenium;

namespace FreeCodeCamp.Features.Hooks
{
    [Binding]
    public class Hook
    {
        public static ConcurrentDictionary<string, ExtentTest> FeatureDictionary = new ConcurrentDictionary<string, ExtentTest>();

        public static ExtentReports Report => extent ?? throw new NullReferenceException("_extent is null. SetExtentReport() first.");


        [ThreadStatic] private static ExtentTest? featureName;

        [ThreadStatic] private static ExtentTest? scenario;

        private static ExtentReports? extent ;
        
        [ThreadStatic]
        public static DirectoryInfo? CurrentTestDirectory;

        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private ScenarioStepContext? _scenarioStepContext;

        public Hook(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            if (featureContext == null) throw new ArgumentNullException("featureContext");
            _featureContext = featureContext;
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            FW.SetConfig();
            FW.CreateTestResultDirectory();
            extent = SetExtentReport();
        }
       
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            //_featureContext = featurecontext;
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);

            FeatureDictionary.TryAdd(featurecontext.FeatureInfo.Title, featureName);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            FW.SetLogger();
            Driver.Init();
            HrmApp.Init();
            scenario = InitScenario();
        }
        [BeforeStep]
        public static void BeforeStepsRun(ScenarioContext Scenario)
        {
            FW.Log.Step(Scenario.StepContext.StepInfo.Text.ToString());
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            _scenarioStepContext = _scenarioContext.StepContext;
            var stepType = _scenarioStepContext.StepInfo.StepDefinitionType.ToString();
            object TestResult = _scenarioContext.ScenarioExecutionStatus;
            Console.WriteLine("TestResult : " + TestResult);

            /* var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
             PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
             MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
             object TestResult = getter.Invoke(sc, null);*/

            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
            else if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioStepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioStepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioStepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioStepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                var MediaEntity = CreateScreenshotforExtentReport(Driver.Current);

                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioStepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioStepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioStepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioStepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, MediaEntity);
            }
            extent.Flush();
        }

        [AfterScenario("retry")]
        public static void Retry()
        {
             if (ScenarioContext.Current.TestError != null)
            {
                // ?     
            }
        }


        private MediaEntityModelProvider CreateScreenshotforExtentReport(IWebDriver drv)
        {
            string ScreenShotName = DateTime.Now.ToString("yyyyMMddHHmmss");
            var ScreenShot = ((ITakesScreenshot)drv).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(ScreenShot, ScreenShotName).Build();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    TakeScreenShotOfFailedPage();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Driver.Current.Quit();
            extent.Flush();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        private static ExtentReports SetExtentReport()
        {
            var testResultDir = FW.WORKSPACE_DIRECTORY + @"TestResults\ExtentReport\";
            if (!Directory.Exists(testResultDir))
            {
                Directory.CreateDirectory(testResultDir);
            }

            var htmlReporter = new ExtentHtmlReporter(testResultDir);
            //htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("OS", "Windows");
            extent.AddSystemInfo("Host Name", "CI");
            extent.AddSystemInfo("Environment", "Atmosphere QA");
            extent.AddSystemInfo("User Name", "MohamadZabiulla");

            htmlReporter.LoadConfig(FW.WORKSPACE_DIRECTORY + @"Framework\extent-config.xml");
            return extent;
        }

        private ExtentTest InitScenario()
        {
            string _featureName = _featureContext.FeatureInfo.Title;
            if (FeatureDictionary.ContainsKey(_featureName))
            {
                scenario = FeatureDictionary[_featureName].CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            }
            return scenario;
        }

        private void TakeScreenShotOfFailedPage()
        {
            Screenshot ScreenShot = ((ITakesScreenshot)Driver.Current).GetScreenshot();
            string Title = _scenarioContext.ScenarioInfo.Title;
            string ScreenShotName = Title.Substring(0, 15) + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            var ScreenShotDirectory = FW.WORKSPACE_DIRECTORY + @"TestResults\ScreenShots\";

            string ScreenShotFileName = ScreenShotDirectory + ScreenShotName + ".png";
            if (!Directory.Exists(ScreenShotName))
            {
                Directory.CreateDirectory(ScreenShotDirectory);
                ScreenShot.SaveAsFile(ScreenShotFileName);
                string UrlFile = Path.GetFullPath(ScreenShotFileName);
                FW.Log.Info($"Screenshot: ->{new Uri(UrlFile)}");
                TestContext.AddTestAttachment(UrlFile, "ScreenShot");
            }
            else
            {
                ScreenShot.SaveAsFile(ScreenShotFileName);
                string UrlFile = Path.GetFullPath(ScreenShotFileName);
                FW.Log.Info($"Screenshot: ->{new Uri(UrlFile)}");
                TestContext.AddTestAttachment(UrlFile, "ScreenShot");
            }
        }

    }
}
