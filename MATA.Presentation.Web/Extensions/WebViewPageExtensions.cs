using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Extensions
{
    public static class WebViewPageExtensions
    {
        public static void AddAuditColumns<TModel>(this WebViewPage<TModel> webViewPage, IList<WebGridColumn> columns)
        {
            columns.Add(new WebGridColumn
            {
                ColumnName = "CreatedBy"
            });

            columns.Add(new WebGridColumn
            {
                ColumnName = "CreateTime"
            });

            columns.Add(new WebGridColumn
            {
                ColumnName = "UpdatedBy"
            });

            columns.Add(new WebGridColumn
            {
                ColumnName = "UpdateTime"
            });
        }
    }
}