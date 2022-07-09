//using Applitools.Selenium;
using Framework;
using Framework.Selenium;
//using Framework.Utilities.Applitools;
using FreeCodeCamp.Tests.Base;
using FreeCodeCamp.Tests.Data;
using FreeCodeCamp.WebPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.Tests
{
    class HRMTests:TestBase
    {

        [Test, Category("HomePage")]
        [Parallelizable]
        public void LoginLogoutTest()
        {
            string title = HrmApp.GoToOrangeHrmApplication().EnterUserName("Admin").EnterPassword("admin123").ClickOnLogin()
                .ClickOnWelcome().ClickLogout()
                .GetTiltle();

            Assert.That(title, Is.EqualTo("OrangeHRM"));
        }

        [Test,Category("HomePage")]
        [Parallelizable]
        public void LoginLogoutTest_Sample()
        {
            HrmApp.GoToOrangeHrmApplication().EnterUserName("Admin").EnterPassword("admin123").ClickOnLogin();
            //.ClickOnWelcome().ClickLogout()
            //.GetTiltle();

            FW.Log.Info("Hii");
            //Assert.That(title, Is.EqualTo("OrangeHRM"));
        }

        /*this will only generate tests for all the unique pairs of those values. When we add the [Pairwise] attribute to our test method*/
        [Test,Category("HomePage")]
        [Parallelizable]
        [Pairwise]
        public void LoginLogoutTestWithParameter(
            [Values("Admin", "Admin1")] string UN, 
            [Values("admin123", "admin1234")] string PW)
        {
            string title = HrmApp.GoToOrangeHrmApplication().EnterUserName(UN).EnterPassword(PW).ClickOnLogin()
                .ClickOnWelcome().ClickLogout()
                .GetTiltle();

            Assert.That(title, Is.EqualTo("OrangeHRM"));
        }

        [Test, Category("HomePage1")]
        [Parallelizable]
        [Sequential]
        public void LoginLogoutTestWithParameter_Sequential(
            [Values("Admin", "Admin1")] string UN,
            [Values("admin123", "admin1234")] string PW)
        {
            string title = HrmApp.GoToOrangeHrmApplication().EnterUserName(UN).EnterPassword(PW).ClickOnLogin()
                .ClickOnWelcome().ClickLogout()
                .GetTiltle();

            Assert.That(title, Is.EqualTo("OrangeHRM"));
        }


        [TestCase("Admin", "admin123",Description ="It should Pass")]
        [TestCase("Admin", "admin1234",Description ="It Should Fail")]
        public void LoginLogoutTest_TestCase(string UN,string PWD)
        {
            string title = HrmApp.GoToOrangeHrmApplication().EnterUserName(UN).EnterPassword(PWD).ClickOnLogin()
                .ClickOnWelcome().ClickLogout()
                .GetTiltle();

            Assert.That(title, Is.EqualTo("OrangeHRM"));
        }

        [TestCaseSource(typeof(TestData),nameof(TestData.LoginDetails))]
        public void LoginLogoutTest_TestCaseSource(string UN, string PWD)
        {
            string title = HrmApp.GoToOrangeHrmApplication().EnterUserName(UN).EnterPassword(PWD).ClickOnLogin()
                .ClickOnWelcome().ClickLogout()
                .GetTiltle();

            Assert.That(title, Is.EqualTo("OrangeHRM"));
        }
    }
}
