using Framework.Selenium;
using Framework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Map.FileSubmit_Btn.Click();
        }

        public string GetFileName()
        {
            return Map.UploadedFiles_Btn.Text;
        }

        public void SendFile(string fileName)
        {
            string filePath = Utils.GetFilePathName(fileName);
            Map.ChooseFile_Btn.SendKeys(filePath);
        }

    }

    public class HerokuApp_Map
    {
        public Element ChooseFile_Btn => Driver.FindElement(By.Id("file-upload"),"File Upload");
        public Element FileSubmit_Btn => Driver.FindElement(By.Id("file-submit"), "file-submit");
        public Element UploadedFiles_Btn => Driver.FindElement(By.Id("uploaded-files"), "uploaded-files");
    }
}
