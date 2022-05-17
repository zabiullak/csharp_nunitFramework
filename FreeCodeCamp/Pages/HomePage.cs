using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.Pages
{
    public class HomePage
    {
        public readonly HomePageMap Map;

        public HomePage()
        {
            Map = new HomePageMap();
        }

        public HomePage Goto()
        {
            HeaderNav.Map.DeckBuilderLink.Click();
            return this;
        }

    }

    public class HomePageMap
    {

    }
}
