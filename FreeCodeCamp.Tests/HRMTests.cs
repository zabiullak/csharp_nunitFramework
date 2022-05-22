using FreeCodeCamp.Tests.Base;
using FreeCodeCamp.WebPages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.Tests
{
    class HRMTests:TestBase
    {
        [Test,Category("HomePage")]
        [Parallelizable]
        public void LoginLogoutTest()
        {
            string title =  Pages.GoToOrangeHrmApplication().EnterUserName("Admin").EnterPassword("admin123").ClickOnLogin()
                .ClickOnWelcome().ClickLogout()
                .GetTiltle();

            Assert.That(title, Is.EqualTo("OrangeHRM"));
        }
    }
}
