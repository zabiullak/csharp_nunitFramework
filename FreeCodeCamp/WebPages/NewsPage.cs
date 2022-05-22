using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.WebPages
{
    public class NewsPage : PageBase
    {
        public readonly NewsPageMap Map;

        public NewsPage()
        {
            Map = new NewsPageMap();
        }

        public List<string> GetTheNewsTitle()
        {
            List<string> _title = new List<string>();
            int _count = Map.Lnk_News.Count;
            IList<IWebElement> list = Map.Lnk_News;
            //var displayedSelectElements = list.Where(se => se.Displayed);
            foreach (IWebElement ele in list)
            {
                _title.Add(ele.Text.Trim());
            }
            return _title;
        }
    }
    public class NewsPageMap
    {
        public Elements Lnk_News => Driver.FindElements(By.CssSelector("a[href*='/news']"));
    }
}
