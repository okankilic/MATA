using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.DTO;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace MATA.Presentation.Web.Filters
{
    public class AuthenticateUserAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        IAccountBL accountBL;
        IUnitOfWorkFactory uowFactory;
        ILogger logger;

        IDependencyResolver dependencyResolver;

        IDependencyResolver CurrentDependencyResolver
        {
            get
            {
                if(dependencyResolver == null)
                {
                    return DependencyResolver.Current;
                }
                else
                {
                    return dependencyResolver;
                }
            }

            set
            {
                dependencyResolver = value;
            }
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (IsAnonymousAction(filterContext.ActionDescriptor) == true)
            {
                return;
            }

            accountBL = CurrentDependencyResolver.GetService<IAccountBL>();
            uowFactory = CurrentDependencyResolver.GetService<IUnitOfWorkFactory>();
            logger = CurrentDependencyResolver.GetService<ILogger>();

            FormsAuthenticationTicket ticket = null;

            try
            {
                ticket = AuthenticationHelper.GetTicket(filterContext.HttpContext);
            }
            catch (Exception ex)
            {
                logger.Debug(ex, "An error occured and supressed while trying to get FormsAuthentication ticket");

                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var userData = AuthenticationHelper.GetUserData(filterContext.HttpContext);

            AccountDTO account = null;

            try
            {
                using (var uow = uowFactory.CreateNew())
                {
                    account = accountBL.GetByToken(userData.TokenString, uow);
                }
            }
            catch (Exception exc)
            {
                logger.Debug(exc, "Exception occured and suppressed while checking for authentication by token");
            }

            if (account == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            ticket = AuthenticationHelper.CreateTicket(userData.TokenString, account, ticket.IsPersistent);

            var identity = new FormsIdentity(ticket);

            filterContext.Principal = new GenericPrincipal(identity, new string[] { account.RoleName });
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (IsAnonymousAction(filterContext.ActionDescriptor) == true)
            {
                return;
            }

            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Path);
            }
        }

        private bool IsAnonymousAction(ActionDescriptor actionDescriptor)
        {
            return actionDescriptor.GetCustomAttributes(inherit: true).OfType<AllowAnonymousAttribute>().Any();
        }
    }
}