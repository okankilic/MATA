using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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
            stringBuilder.Append($"\">{Resources.Properties.Resources.Loading}</div>");
            stringBuilder.Append("</div>");
            stringBuilder.Append("</div>");

            return new HtmlString(stringBuilder.ToString());
        }

        public static string LocalizeEnum<TEnum>(this HtmlHelper htmlHelper, TEnum t, object value)
        {
            return htmlHelper.Localize(string.Format("{0}_{1}", typeof(TEnum).Name, value));
        }

        public static string Localize(this HtmlHelper htmlHelper, string key)
        {
            return Resources.Properties.Resources.ResourceManager.GetString(key);
        }

        public static string LocalizeFormat(this HtmlHelper htmlHelper, string formatKey, params object[] args)
        {
            var format = Resources.Properties.Resources.ResourceManager.GetString(formatKey);

            return string.Format(format, args);
        }

        public static IHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string textKey, string actionName, string controllerName)
        {
            var linkText = Resources.Properties.Resources.ResourceManager.GetString(textKey);

            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public static IHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string textKey, string actionName, object routeValues)
        {
            var linkText = Resources.Properties.Resources.ResourceManager.GetString(textKey);

            return htmlHelper.ActionLink(linkText, actionName, routeValues);
        }

        public static IHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string textKey, string actionName, object routeValues, object htmlAttributes)
        {
            var linkText = Resources.Properties.Resources.ResourceManager.GetString(textKey);

            return htmlHelper.ActionLink(linkText, actionName, routeValues, htmlAttributes);
        }

        public static IHtmlString LocalizedActionLink(this HtmlHelper htmlHelper, string textKey, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var linkText = Resources.Properties.Resources.ResourceManager.GetString(textKey);

            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        }

        public static IHtmlString ShowCheck(this HtmlHelper htmlHelper, bool isChecked)
        {
            return htmlHelper.Raw("<span class=\"glyphicon " + (isChecked ? "glyphicon-ok" : "glyphicon-remove") + "\" span></span>");
        }

        public static IHtmlString ShowAuditInfo<TModel>(this HtmlHelper<TModel> htmlHelper)
            where TModel: AuditDTO
        {
            var sb = new StringBuilder();

            sb.Append("<div class=\"panel panel-default\">");
            sb.Append("<div class=\"panel-body\">");
            sb.Append("<h4>");
            sb.Append(Resources.Properties.Resources.AuditInfo);
            sb.Append("</h4>");
            sb.Append("<hr />");
            sb.Append("<dl>");
            sb.Append("<dt>");
            sb.Append(htmlHelper.DisplayNameFor(model => model.CreatedBy) + " / " + htmlHelper.DisplayNameFor(model => model.CreateTime));
            sb.Append("</dt>");
            sb.Append("<dd>");
            sb.Append(htmlHelper.DisplayFor(model => model.CreatedBy) + " ( " + htmlHelper.DisplayFor(model => model.CreateTime) + ")");
            sb.Append("</dd>");
            sb.Append("<dt>");
            sb.Append(htmlHelper.DisplayNameFor(model => model.UpdatedBy) + " / " + htmlHelper.DisplayNameFor(model => model.UpdateTime));
            sb.Append("</dt>");
            sb.Append("<dd>");
            sb.Append(htmlHelper.DisplayFor(model => model.UpdateTime) + " ( " + htmlHelper.DisplayFor(model => model.UpdateTime) + ")");
            sb.Append("</dd>");
            sb.Append("</dl>");
            sb.Append("</div>");
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }

        public static WebGridColumn LocalizedDetailsActionLinkColumn<TModel>(this HtmlHelper<TModel> htmlHelper, string columnName, string linkColumnName, string controllerName)
        {
            var column = new WebGridColumn
            {
                Header = Resources.Properties.Resources.ResourceManager.GetString(columnName),
                Format = (item) => htmlHelper.ActionLink((string)item[columnName], "Details", controllerName, new { id = item[linkColumnName] }, null)
            };

            return column;
        }
    }
}