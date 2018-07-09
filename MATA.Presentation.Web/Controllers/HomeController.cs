using MATA.Data.Common.Constants;
using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Exceptions;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class HomeController : CustomControllerBase
    {
        public HomeController(IUnitOfWorkFactory uowFactory, ILogger logger) : base(uowFactory, logger)
        {
        }
        
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