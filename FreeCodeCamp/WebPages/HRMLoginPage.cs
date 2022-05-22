using Framework.Selenium;
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
            return this;
        }

        public HRMLoginPage EnterPassword(string password)
        {
            Map.TextboxPassword.SendKeys(password);
            return this;
        }

        public HRMHomePage ClickOnLogin()
        {
            Map.ButtonLogin.Click();
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