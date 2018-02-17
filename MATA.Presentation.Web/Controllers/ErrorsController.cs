using MATA.Presentation.Web.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class ErrorsController : CustomControllerBase
    {
        public ActionResult Index()
        {
            Response.StatusCode = 500;

            return View();
        }

        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }

        public ActionResult Internal(string errorMessage)
        {
            ViewData["errorMessage"] = errorMessage;

            Response.StatusCode = 500;

            return View();
        }

        public ActionResult _Partial(string errorMessage)
        {
            ViewData["errorMessage"] = errorMessage;

            Response.StatusCode = 500;

            return PartialView();
        }
    }
}