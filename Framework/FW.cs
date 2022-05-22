using Framework.Logging;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

        public static FwConfig Config => _configuration ?? throw new NullReferenceException("Config is null. Call FW.SetConfig() first");

        private static FwConfig _configuration;

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        public static Logger _logger;

        public static DirectoryInfo CreateTestResultDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY + "TestResults";
            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetLogger()
        {
            lock (_setLoggerLock)
            {
                var testResultDir = WORKSPACE_DIRECTORY + "TestResults";
                var testName = TestContext.CurrentContext.Test.Name;
                var fullPath = $"{testResultDir}/{testName}";

                if (Directory.Exists(fullPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                }

                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }
        }

        private static object _setLoggerLock = new object();

        public static void SetConfig()
        {
            if(_configuration == null)
            {
                var jsonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/framework-config.json");
                _configuration = JsonConvert.DeserializeObject<FwConfig>(jsonStr);
            }
        }
    }
}
