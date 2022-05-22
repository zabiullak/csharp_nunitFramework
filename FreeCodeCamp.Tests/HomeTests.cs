using FreeCodeCamp.Tests.Base;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using FreeCodeCamp.WebPages;
using Framework;

namespace FreeCodeCamp.Tests
{
    public class HomeTests : TestBase 
    {
        [Test,Category("HomePage")]
        public void printAllNewsHeadings()
        {
            List<string> lstOfNews = Pages.GotoFreeCodeCamp().GotoMenu().ClickOnNews().GetTheNewsTitle();
            foreach(string name in lstOfNews) {
                FW.Log.Info(name);
            }
            Assert.That(lstOfNews, Is.Not.Empty.Or.Not.Null);
        }
    }
}