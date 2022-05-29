using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.Tests.Data
{
    public class TestData
    {
        public static string[] Passwords()
        {
            return new[]
            {
                "admin123",
                "Adiosn34",
                "JInd"
            };
        }

        public static object[] LoginDetails()
        {
            return new object[]
            {
                new object[]{"Admin","admin123"},
                new object[]{"Admin","admin1234"}
            };
        }
        
    }
}
