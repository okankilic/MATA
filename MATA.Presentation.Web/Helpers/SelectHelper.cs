using MATA.Data.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Helpers
{
    public static class SelectHelper
    {
        public static IEnumerable<SelectListItem> GetRoleTypes(string selectedRoleType)
        {
            var roles = RoleTypes.GetRoleTypes().Select(q => new SelectListItem
            {
                Text = Resources.Properties.Resources.ResourceManager.GetString(string.Format("RoleTypes_{0}", q)),
                Value = q,
                Selected = q.Equals(selectedRoleType)
            });

            return roles;
        }
    }
}