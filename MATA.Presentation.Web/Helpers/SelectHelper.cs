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
        public static SelectList GetRoleTypes(string selectedRoleType)
        {
            return new SelectList(RoleTypes.GetRoleTypes(), selectedRoleType);
        }
    }
}