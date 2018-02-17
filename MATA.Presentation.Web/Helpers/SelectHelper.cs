using MATA.Data.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Helpers
{
    public class SelectHelper
    {
        public static SelectList GetRoleTypeList(string selectedRoleType = null)
        {
            var selectList = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem(){ Value = null, Text = "" },
                new SelectListItem(){ Value = RoleTypes.Admin, Text = "Admin" },
                new SelectListItem(){ Value = RoleTypes.Staff, Text = "Çalışan" },
                new SelectListItem(){ Value = RoleTypes.Customer, Text = "Müşteri" }
            }, "Value", "Text", selectedRoleType);

            return selectList;
        }
    }
}