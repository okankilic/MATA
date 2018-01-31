using MATA.Data.Common.Constants;
using MATA.Data.Entities;
using MATA.Presentation.Web.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Base
{
    [AuthenticateUser]
    [Authorize(Roles = RoleTypes.Combines.Any)]
    public abstract class CustomControllerBase: Controller
    {
        protected MataDBEntities _DB = new MataDBEntities();

        protected Logger _Logger = LogManager.GetCurrentClassLogger();
    }
}