using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.WebPages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public HeaderNav GotoMenu()
        {
            Map.Btn_Menu.Click();
            return this;
        }

        public NewsPage ClickOnNews()
        {
            Map.Lnk_News.Click();
            //Driver.Window.SwitchTo(1);
            //Driver.Window.SwitchTo(0);
            return new NewsPage();
        }

    }
    public class HeaderNavMap
    {
        public Element Btn_Menu => Driver.FindElement(By.XPath("//button[@class='toggle-button-nav']"),"Menu Button");
        public Element Lnk_News => Driver.FindElement(By.XPath("//a/span[.='News']"), "News");
    }

}
