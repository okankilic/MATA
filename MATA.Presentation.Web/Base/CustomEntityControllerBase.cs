using MATA.Data.Common.Constants;
using MATA.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Base
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public abstract class CustomEntityControllerBase<TDTO>: CustomControllerBase
    {
        public const int DefaultPageSize = 10;

        public abstract ActionResult Index(int page = 1);

        public abstract ActionResult Details(int id);

        public abstract ActionResult _Create();

        public abstract ActionResult Create(TDTO dto);

        public abstract ActionResult _Edit(int id);

        public abstract ActionResult Edit(int id, TDTO dto);

        public abstract ActionResult Delete(int id);
    }
}