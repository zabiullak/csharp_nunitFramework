using Framework;
using Framework.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.WebPages
{
    public class Pages
    {
        [ThreadStatic]
        public static HomePage Home;

        public static HeaderNav Header;
        public static HRMLoginPage HRMLoginPage;

       
        public static void Init()
        {
            Home = new HomePage();
            Header = new HeaderNav();
            HRMLoginPage = new HRMLoginPage();
        }

        public static HRMLoginPage GoToOrangeHrmApplication()
        {
            Driver.Goto(FW.Config.Test.url_orangeHRM);
            return new HRMLoginPage();
        }

        public static HomePage GotoFreeCodeCamp()
        {
            Driver.Goto(FW.Config.Test.url_freeCodeCamp);
            return new HomePage();
        }

    }
}
