using Framework;
using Framework.Selenium;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utilities;
using OpenQA.Selenium;

namespace FreeCodeCamp.WebPages
{
    public class Sikuli_Page
    {
        private readonly HRMLoginPages_Map Map;

        public Sikuli_Page()
        {
            Map = new HRMLoginPages_Map();
        }

        public void GoToOrangeHrmApplication(string url)
        {
            Driver.Goto(url);
            FW.Log.Info($"Landed on Url -> {url}");
        }

        public Sikuli_Page EnterUserName(string username)
        {
            Map.TextboxUsername.SendKeys(username);
            FW.Log.Info("Entered Username");
            return this;
        }

        public Sikuli_Page EnterPassword(string password)
        {
            Map.TextboxPassword.SendKeys(password);
            FW.Log.Info("Entered Password");
            return this;
        }

        public void ClickOnLogin()
        {
            Map.ButtonLogin.Click();
            FW.Log.Info("Clicked on Login btn");
        }

        public void ClickOnLoginUsingSikuli(string ImageName)
        {
            APILauncher launch = new APILauncher(true);
            string ImagePath = Utils.GetSikuliImages(ImageName);
            Pattern Image1 = new Pattern(ImagePath);
            launch.Start();
            Screen scr = new Screen();
            scr.Wait(Image1, 2);
            scr.Click(Image1, true);
        }

        public string GetTiltle()
        {
            return Driver.Current.Title;
        }
    }

    public class HRMLoginPages_Map
    {
        public Element TextboxUsername => Driver.FindElement(By.Id("txtUsername"), "UserName");
        public Element TextboxPassword => Driver.FindElement(By.XPath("//input[@id='txtPassword' and @type='password']"), "Password");
        public Element ButtonLogin => Driver.FindElement(By.Id("btnLogin"), "Login");
    }
}
