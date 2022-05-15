using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace FreeCodeCamp.Test
{
    public class HomeTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
           _driver = new ChromeDriver();
            _driver.Url = "https://www.freecodecamp.org/";
        }
    }
}