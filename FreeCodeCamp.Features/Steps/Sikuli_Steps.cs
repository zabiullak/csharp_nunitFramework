using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FreeCodeCamp.WebPages;
using NUnit.Framework;

namespace FreeCodeCamp.Features.Steps
{

    [Binding]
    public sealed class Sikuli_Steps
    {

        [Given(@"User Launch the '(.*)' URL")]
        public void GivenUserLaunchTheURL(string url)
        {
            HrmApp.Sikuli_Page.GoToOrangeHrmApplication(url);
        }

        [Given(@"Enter UN as '(.*)' and PWD as '(.*)'")]
        public void GivenEnterUNAsAndPWDAs(string UN, string PWD)
        {
            HrmApp.Sikuli_Page.EnterUserName(UN).EnterPassword(PWD);
        }

        [Then(@"Click on Login using Sikuli Actions")]
        public void ThenClickOnLoginUsingSikuliActions()
        {
            //WebPages._sikuliPage.ClickOnLoginUsingSikuli();
            HrmApp.Sikuli_Page.ClickOnLoginUsingSikuli("Login.png");
        }

    }
}
