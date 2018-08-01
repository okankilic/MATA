using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString PartialViewContainer(this HtmlHelper htmlHelper, string url)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<div class=\"panel panel-default\">");
            stringBuilder.Append("<div class=\"panel-body\">");
            stringBuilder.Append("<div class=\"mt-partial-view-container\" data-url=\"");
            stringBuilder.Append(url);
            stringBuilder.Append("\">Yükleniyor...</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");

            return new HtmlString(stringBuilder.ToString());
        }
    }
}