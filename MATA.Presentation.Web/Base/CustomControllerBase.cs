using MATA.Data.Common.Constants;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        protected const int DefaultPageSize = 10;

        protected IUnitOfWorkFactory uowFactory;
        protected ILogger logger;

        public CustomControllerBase(IUnitOfWorkFactory uowFactory, ILogger logger)
        {
            this.uowFactory = uowFactory;
            this.logger = logger;
        }

        public string TokenString
        {
            get
            {
                return AuthenticationHelper.GetTokenString(HttpContext);
            }
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var languages = Request.Headers["Accept-Language"].Split(';');

            var preferredLanguage = languages[0];

            var language = (preferredLanguage.Contains(',')) ? preferredLanguage.Split(',')[1] : preferredLanguage;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }
    }
}