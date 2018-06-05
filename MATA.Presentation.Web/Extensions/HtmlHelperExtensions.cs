using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString PartialViewContainer(this HtmlHelper htmlHelper, string url)
        {
            var html = "<div class=\"mt-partial-view-container\" data-url=\"" + url + "\">Yükleniyor...</div>";

            return new HtmlString(html);
        }
    }
}