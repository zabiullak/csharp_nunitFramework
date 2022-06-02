using Applitools;
using Applitools.Selenium;
using Framework.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration = Applitools.Configuration;

namespace Framework.Utilities.Applitools
{
    public class ApplitoolsEyes
    {
        [ThreadStatic]
        private static Configuration config;

        [ThreadStatic]
        private static EyesRunner runner;

        [ThreadStatic]
        private static Eyes _eyes;

        public static Eyes Current => _eyes ?? throw new NullReferenceException("_eyes is null.");


        public static void Init()
        {
            if (FW.Config.Activate.applitools_eye)
            {
                runner = new ClassicRunner();
                _eyes = new Eyes(runner);
                SetUp();
                FW.Log.Info("<<--applitools_eye is : true in Config file, Initialized Eyes-->>");
            }
            else
            {
                FW.Log.Info("<<--applitools_eye is : false in Config file-->>");
            }
        }

        private static void SetUp()
        {
            // Initialize the eyes configuration.
            config = new Configuration();

            // Add this configuration if your tested page includes fixed elements.
            //config.setStitchMode(StitchMode.CSS);

            // You can get your api key from the Applitools dashboard
            config.SetApiKey("FsX59WEy105G0Fo6TyHnBjdX66JxOMoHwABmxEDgK7E7E110");

            // set new batch
            config.SetBatch(new BatchInfo("June Sparking Batch"));

            // set the configuration to eyes
            _eyes.SetConfiguration(config);
        }

        public static void TearDownEyes()
        {
            if (FW.Config.Activate.applitools_eye)
            {
                _eyes.Close();
                // If the test was aborted before eyes.close was called, ends the test as aborted.
                _eyes.AbortIfNotClosed();

                //Wait and collect all test results
                // we pass false to this method to suppress the exception that is thrown if we
                // find visual differences
                TestResultsSummary allTestResults = runner.GetAllTestResults(false);

                // Print results
                Console.WriteLine(allTestResults);
            }
        }

    }
}
