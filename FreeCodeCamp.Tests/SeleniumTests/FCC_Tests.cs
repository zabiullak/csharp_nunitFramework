using FreeCodeCamp.Tests.Base;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using FreeCodeCamp.WebPages;
using Framework;

namespace FreeCodeCamp.Tests
{
    public class FCC_Tests : TestBase
    {
        [Test, Category("HomePage")]
        [Parallelizable]
        [Order(1)]
        public void PrintAllNewsHeadings()
        {
            List<string> lstOfNews = HrmApp.GotoFreeCodeCamp().GotoMenu().ClickOnNews().GetTheNewsTitle();
            foreach (string name in lstOfNews) {
                FW.Log.Info(name);
            }
            Assert.That(lstOfNews, Is.Not.Empty.Or.Not.Null);
        }

        //[Test, Category("HomePage")]
        [Test(Author = "Zabi", Description = "Trial Tests"), Category("HomePage")]
        [Parallelizable]
        [Order(2)]
        public void PrintAllNewsHeadings1()
        {
            List<string> lstOfNews = HrmApp.GotoFreeCodeCamp().GotoMenu().ClickOnNews().GetTheNewsTitle();
            foreach (string name in lstOfNews)
            {
                FW.Log.Info(name);
            }
            Assert.That(lstOfNews, Is.Not.Empty.Or.Not.Null);
        }

        [Test, Category("HomePage")]
        [Parallelizable]
        [Explicit("No need to run this Test Case")]
        [Ignore("Check the Ignor is Working?")]
        [Order(3)]
        public void PrintAllNewsHeadings2()
        {
            List<string> lstOfNews = HrmApp.GotoFreeCodeCamp().GotoMenu().ClickOnNews().GetTheNewsTitle();
            foreach (string name in lstOfNews)
            {
                FW.Log.Info(name);
            }
            Assert.That(lstOfNews, Is.Not.Empty.Or.Not.Null);
        }

        [Test, Category("HomePage")]
        [Parallelizable]
        [Order(4)]
        [Platform(Include ="Widows")]
        public void PrintAllNewsHeadings3()
        {
            List<string> lstOfNews = HrmApp.GotoFreeCodeCamp().GotoMenu().ClickOnNews().GetTheNewsTitle();
            foreach (string name in lstOfNews)
            {
                FW.Log.Info(name);
            }
            Assert.That(lstOfNews, Is.Not.Empty.Or.Not.Null);
        }
    }
}