using Framework.Selenium;
using OpenQA.Selenium;
using System;

namespace FreeCodeCamp.WebPages
{
    public class HRMHomePage
    {
        private readonly HRMHomePage_Map Map;
        public HRMHomePage()
        {
            Map = new HRMHomePage_Map();
        }

        public HRMHomePage ClickOnWelcome()
        {
            Map.LinkWelcome.Click();
            return this;
        }

        public HRMLoginPage ClickLogout()
        {
            Map.LinkLogout.Click();
            return new HRMLoginPage();
        }
    }
    public class HRMHomePage_Map
    {
        public Element LinkWelcome => Driver.FindElement(By.Id("welcome"),"Welcome link");
        public Element LinkLogout => Driver.FindElement(By.XPath("//a[text()='Logout']"), "Logout button");
    }
}