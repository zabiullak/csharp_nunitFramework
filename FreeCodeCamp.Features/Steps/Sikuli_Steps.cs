using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FreeCodeCamp.WebPages;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]

namespace FreeCodeCamp.Features.Steps
{

    [Binding]
    public sealed class Sikuli_Steps
    {

        [Given(@"User Launch the '(.*)' URL")]
        public void GivenUserLaunchTheURL(string url)
        {
            Pages.Sikuli_Page.GoToOrangeHrmApplication(url);
        }

        [Given(@"Enter UN as '(.*)' and PWD as '(.*)'")]
        public void GivenEnterUNAsAndPWDAs(string UN, string PWD)
        {
            Pages.Sikuli_Page.EnterUserName(UN).EnterPassword(PWD);
        }

        [Then(@"Click on Login using Sikuli Actions")]
        public void ThenClickOnLoginUsingSikuliActions()
        {
            //WebPages._sikuliPage.ClickOnLoginUsingSikuli();
            Pages.Sikuli_Page.ClickOnLoginUsingSikuli("Login.png");
        }

    }
}
