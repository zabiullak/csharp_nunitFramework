using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.WebPages
{
    public class HomePage:PageBase
    {
        public readonly HomePageMap Map;

        public HomePage()
        {
            Map = new HomePageMap();
        }

        public HeaderNav GotoMenu()
        {
            HeaderNav.GotoMenu();
            return HeaderNav;
        }
    }

    public class HomePageMap
    {

    }
}
