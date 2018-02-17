using MATA.Infrastructure.Utils.Exceptions;
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
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            var ex = filterContext.Exception;

            if (ex.InnerException != null)
                ex = ex.InnerException;

            filterContext.ExceptionHandled = true;

            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);

            var exMessage = ex.Message;

            if(ex is BusinessException)
            {
                // do nothing
            }
            else
            {
                exMessage = "Beklenmeyen bir hata oluştu";
            }

            var routeValueDictionary = new RouteValueDictionary();

            routeValueDictionary.Add("controller", "Errors");

            if (filterContext.HttpContext.Request.IsAjaxRequest())
                routeValueDictionary.Add("action", "_Partial");
            else
                routeValueDictionary.Add("action", "Internal");

            routeValueDictionary.Add("errorMessage", exMessage);

            filterContext.Result = new RedirectToRouteResult(routeValueDictionary);
        }
    }
}