using Framework;
using Framework.Selenium;
using FreeCodeCamp.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp
{
    public class HrmApp
    {
        [ThreadStatic] public static HomePage Home;

        [ThreadStatic] public static HRMHomePage HRMHomePage;

        [ThreadStatic] public static HRMLoginPage HRMLoginPage;

        [ThreadStatic] public static NewsPage NewsPage;

        [ThreadStatic] public static Sikuli_Page Sikuli_Page;

        [ThreadStatic] public static HerokuApp HerokuApp;


        public static void Init()
        {
            Sikuli_Page = new Sikuli_Page();
            Home = new HomePage();
            HRMLoginPage = new HRMLoginPage();
            HRMHomePage = new HRMHomePage();
            NewsPage = new NewsPage();
            HerokuApp = new HerokuApp();
        }

        public static HRMLoginPage GoToOrangeHrmApplication()
        {
            Driver.Goto(FW.Config.Test.url_orangeHRM);
            FW.Log.Info($"Landed on Url -> {FW.Config.Test.url_orangeHRM}");
            return new HRMLoginPage();
        }

        public static HomePage GotoFreeCodeCamp()
        {
            Driver.Goto(FW.Config.Test.url_freeCodeCamp);
            FW.Log.Info($"Landed on Url -> {FW.Config.Test.url_freeCodeCamp}");
            return new HomePage();
        }

    }
}
