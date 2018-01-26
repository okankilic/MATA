using MATA.BL;
using MATA.Data.DTO;
using MATA.Data.Entities;
using MATA.Presentation.Web.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace MATA.Presentation.Web.Filters
{
    public class AuthenticateUserAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private readonly MataDBEntities _DB = new MataDBEntities();

        private readonly Logger _Logger = LogManager.GetCurrentClassLogger();

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (IsAnonymousAction(filterContext.ActionDescriptor) == true)
                return;

            FormsAuthenticationTicket ticket = null;

            try
            {
                ticket = AuthenticationHelper.GetTicket(filterContext.HttpContext);
            }
            catch (Exception ex)
            {
                _Logger.Debug(ex, "An error occured and supressed while trying to get FormsAuthentication ticket");

                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var userData = AuthenticationHelper.GetUserData(filterContext.HttpContext);

            AccountDTO account = null;

            try
            {
                account = AccountBL.Get(userData.TokenString, _DB);
            }
            catch (Exception exc)
            {
                _Logger.Debug(exc, "Exception occured and suppressed while checking for authentication by token");
            }

            if (account == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            ticket = AuthenticationHelper.CreateTicket(userData.TokenString, account, ticket?.IsPersistent ?? true);

            var identity = new FormsIdentity(ticket);

            filterContext.Principal = new GenericPrincipal(identity, new string[] { account.RoleName });
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (IsAnonymousAction(filterContext.ActionDescriptor) == true)
                return;

            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Path);
        }

        private bool IsAnonymousAction(ActionDescriptor actionDescriptor)
        {
            return actionDescriptor.GetCustomAttributes(inherit: true).OfType<AllowAnonymousAttribute>().Any();
        }
    }
}