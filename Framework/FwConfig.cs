using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class FwConfig
    {
        public DriverSettings Driver { get; set; }
        public TestSettings Test { get; set; }
        public Activate Activate { get; set; }
    }

    public class Activate
    {
        public bool applitools_eye { get; set; }
    }

    public class DriverSettings
    {
        public string Browser { get; set; }
        public int WaitSeconds { get; set; }
        public string Type { get; set; }
    }

    public class TestSettings
    {
        public string url_freeCodeCamp { get; set; }
        public string url_orangeHRM { get; set; }
    }
}
