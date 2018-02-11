using MATA.Data.Common.Constants;
using MATA.Infrastructure.Utils.Exceptions;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class HomeController : CustomControllerBase
    {
        [AuthorizeUser(Roles = RoleTypes.Customer)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}