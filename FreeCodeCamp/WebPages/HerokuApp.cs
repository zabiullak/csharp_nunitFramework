using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.WebPages
{
    public class HerokuApp
    {
        private readonly HerokuApp_Map Map;

        public HerokuApp()
        {
            Map = new HerokuApp_Map();
        }

        public void ClickOnFileUpload()
        {
            Map.ChooseFile_Btn.Click();
        }
    }

    public class HerokuApp_Map
    {
        public Element ChooseFile_Btn => Driver.FindElement(By.Id("file-upload"),"File Upload");
    }
}
