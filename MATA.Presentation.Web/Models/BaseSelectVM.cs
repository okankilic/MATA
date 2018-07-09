using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Models
{
    public class BaseSelectVM<TDTO>
    {
        public MvcHtmlString SelectName { get; set; }

        public MvcHtmlString SelectID { get; set; }

        public object SelectValue { get; set; }
    }
}