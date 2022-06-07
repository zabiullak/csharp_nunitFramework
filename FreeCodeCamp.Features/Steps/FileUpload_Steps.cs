using FreeCodeCamp.WebPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace FreeCodeCamp.Features.Steps
{
    [Binding]
    public sealed class FileUpload_Steps
    {
        [Then(@"Click on Choose File and Upload a New File")]
        public void ThenClickOnChooseFileAndUploadANewFile()
        {
            HrmApp.HerokuApp.SendFile("Info.txt");
        }

        [Then(@"Verify FileUploaded Successfully")]
        public void ThenVerifyFileUploadedSuccessfully()
        {
            HrmApp.HerokuApp.ClickOnFileUpload();
            string Filename = HrmApp.HerokuApp.GetFileName();
            Assert.That(Filename, Is.EqualTo("Info.txt"));
        }
    }
}
