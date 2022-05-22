using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCodeCamp.WebPages
{
    public abstract class PageBase
    {
        public readonly HeaderNav HeaderNav;

        public PageBase()
        {
            HeaderNav = new HeaderNav();
        }


    }
}
