using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;
        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

    }
    public class HeaderNavMap
    {
        public By asdf = By.XPath("//button[@class='toggle-button-nav']");

    }

}
