using MATA.Infrastructure.Utils.Exceptions;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MATA.Presentation.Web.Filters
{
    public class CustomHandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
        ILogger logger;

        IDependencyResolver dependencyResolver;

        IDependencyResolver CurrentDependencyResolver
        {
            get
            {
                if (dependencyResolver == null)
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

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            logger = CurrentDependencyResolver.GetService<ILogger>();

            var ex = filterContext.Exception;

            if (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            filterContext.ExceptionHandled = true;

            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            
            logger.Error(ex, ex.Message);

            var routeValueDictionary = new RouteValueDictionary
            {
                { "controller", "Errors" }
            };

            var exMessage = ex.Message;

            if (ex is BusinessException)
            {
                // do nothing
            }
            else if (ex is AuthorizationException)
            {
                exMessage = "Bu işlem için yetkiniz bulunmamaktadır";
            }
            else
            {
                exMessage = "Beklenmeyen bir hata oluştu";
            }

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                routeValueDictionary.Add("action", "_Partial");
            }
            else
            {
                routeValueDictionary.Add("action", "Internal");
            }

            routeValueDictionary.Add("errorMessage", exMessage);

            filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
        }
    }
}