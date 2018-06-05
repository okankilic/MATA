using MATA.Data.Common.Constants;
using MATA.Data.Entities;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Base
{
    [AuthenticateUser]
    [AuthorizeUser(Roles = RoleTypes.Combines.Any)]
    [CustomHandleError]
    [OutputCache(Duration = 0)]
    public abstract class CustomControllerBase: Controller
    {
        protected MataDBEntities _DB = new MataDBEntities();

        protected Logger _Logger = LogManager.GetCurrentClassLogger();

        public string TokenString
        {
            get
            {
                return AuthenticationHelper.GetTokenString(HttpContext);
            }
        }
    }
}