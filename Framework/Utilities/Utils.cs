using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utilities
{
    public class Utils
    {
        public static string GetSikuliImages(string image)
        {
            return FW.WORKSPACE_DIRECTORY+ @"Framework\Resources\Images\" + image;
        }
    }
}
