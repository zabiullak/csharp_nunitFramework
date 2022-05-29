using Framework;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace FreeCodeCamp.WebPages
{
    public class HRMLoginPage : PageBase 
    {
        private readonly HRMLoginPage_Map Map;
        public HRMLoginPage()
        {
            Map = new HRMLoginPage_Map();
        }

        public HRMLoginPage EnterUserName(string username)
        {
            Map.TextboxUsername.SendKeys(username);
            FW.Log.Info("Entered Username");
            return this;
        }

        public HRMLoginPage EnterPassword(string password)
        {
            Map.TextboxPassword.SendKeys(password);
            FW.Log.Info("Entered Password");
            //TestContext.AddTestAttachment("Login.png", "after endtering Password");
            return this;
        }

        public HRMHomePage ClickOnLogin()
        {
            Map.ButtonLogin.Click();
            FW.Log.Info("Clicked on Login btn");
            return new HRMHomePage();
        }

        public string GetTiltle()
        {
            return Driver.Current.Title;
        }
    }
    public class HRMLoginPage_Map
    {
        public Element TextboxUsername => Driver.FindElement(By.Id("txtUsername"), "UserName");
        public Element TextboxPassword => Driver.FindElement(By.XPath("//input[@id='txtPassword' and @type='password']"), "Password");
        public Element ButtonLogin => Driver.FindElement(By.Id("btnLogin"), "Login");
    }
}