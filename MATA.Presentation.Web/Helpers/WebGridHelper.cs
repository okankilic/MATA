using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MATA.Presentation.Web.Helpers
{
    public static class WebGridHelper
    {
        public static WebGridColumn LocalizedTextColumn(string columnName)
        {
            var column = new WebGridColumn
            {
                Header = Resources.Properties.Resources.ResourceManager.GetString(columnName),
                ColumnName = columnName
            };

            return column;
        }
    }
}