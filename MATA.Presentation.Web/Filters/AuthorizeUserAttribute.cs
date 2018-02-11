using MATA.Data.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Filters
{
    public class AuthorizeUserAttribute: FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAnonymous = IsAnonymousAction(filterContext.ActionDescriptor);
            if (isAnonymous)
                return;
            
            if (filterContext.HttpContext.User.IsInRole(RoleTypes.Admin))
                return;

            var isAuthorized = AuthorizeCore(filterContext.HttpContext);
            if (isAuthorized)
                return;

            HandleUnauthorizedRequest(filterContext);
        }

        private bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isInRole = false;

            if (httpContext.User.Identity.IsAuthenticated)
            {
                foreach (var role in this.Roles.Split(','))
                {
                    isInRole = httpContext.User.IsInRole(role);
                    if (isInRole)
                        break;
                }
            }

            return isInRole;
        }

        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
            else
                filterContext.Result = new RedirectResult("~/Errors/Unauthorized");
        }

        private bool IsAnonymousAction(ActionDescriptor actionDescriptor)
        {
            return actionDescriptor.GetCustomAttributes(inherit: true).OfType<AllowAnonymousAttribute>().Any();
        }
    }
}