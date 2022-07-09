//using Applitools;
//using Applitools.Selenium;
//using FreeCodeCamp.Tests.Base;
//using FreeCodeCamp.WebPages;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FreeCodeCamp.Tests
//{
//    [TestFixture]
//    public class VisualTesting_Eyes : TestBase
//    {
//        private Eyes eyes;

//        private ChromeDriver driver;

//        [SetUp]
//        public void BeforeEyes()
//        {
//            /* var CI = Environment.GetEnvironmentVariable("CI");
//             var options = new ChromeOptions();
//             if (CI != null)
//             {
//                 options.AddArguments("headless");
//             }*/
//            // Use Chrome browser
//            driver = new ChromeDriver(@"C:\Users\mohamad.khaja\Desktop\HipHipHurray\csharp_nunitFramework\_drivers");

//            //Initialize the Runner for your test.
//            //runner = new ClassicRunner();

//            // Initialize the eyes SDK (IMPORTANT: make sure your API key is set in the APPLITOOLS_API_KEY env variable).
//            //eyes = new Eyes(runner);
//            eyes = new Eyes();

//            SetUp();
//        }

//        [Test]
//        public void BasicTest()
//        {
//            eyes.Open(driver, "Mohamad CSharp work", "this is the first test running with eyes", new Size(800, 600));

//            driver.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";

//            // Visual checkpoint #1
//            eyes.Check(Target.Window().Fully().WithName("Login Window"));

//            HrmApp.Sikuli_Page.EnterUserName("Admin").EnterPassword("admin123");

//            // Visual checkpoint #2 - Check the app page.
//            eyes.Check(Target.Window().Fully().WithName("Home Page HRM"));

//            // End the test.
//            eyes.CloseAsync();
//        }

//        [TearDown]
//        public void AfterEach()
//        {
//            // Close the browser.
//            driver.Quit();

//            // If the test was aborted before eyes.close was called, ends the test as aborted.
//            eyes.AbortIfNotClosed();

//            //Wait and collect all test results
//            // we pass false to this method to suppress the exception that is thrown if we
//            // find visual differences
//            TestResultsSummary allTestResults = runner.GetAllTestResults(false);

//            // Print results
//            Console.WriteLine(allTestResults);
//        }

//        private void SetUp()
//        {
//            // Initialize the eyes configuration.
//            Applitools.Selenium.Configuration config = new Applitools.Selenium.Configuration();

//            // Add this configuration if your tested page includes fixed elements.
//            //config.setStitchMode(StitchMode.CSS);


//            // You can get your api key from the Applitools dashboard
//            config.SetApiKey("FsX59WEy105G0Fo6TyHnBjdX66JxOMoHwABmxEDgK7E7E110");

//            // set new batch
//            config.SetBatch(new BatchInfo("Thurdsay 123 Demo"));

//            // set the configuration to eyes
//            eyes.SetConfiguration(config);
//        }
//    }
//}
