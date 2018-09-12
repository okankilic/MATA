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
                Header = Resources.Properties.Resources.CreatedBy,
                ColumnName = "CreatedBy"
            });

            columns.Add(new WebGridColumn
            {
                Header = Resources.Properties.Resources.CreateTime,
                ColumnName = "CreateTime"
            });

            columns.Add(new WebGridColumn
            {
                Header = Resources.Properties.Resources.UpdatedBy,
                ColumnName = "UpdatedBy"
            });

            columns.Add(new WebGridColumn
            {
                Header = Resources.Properties.Resources.UpdateTime,
                ColumnName = "UpdateTime"
            });
        }
    }
}