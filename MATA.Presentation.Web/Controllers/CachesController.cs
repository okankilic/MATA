using MATA.BL.Interfaces;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class CachesController : CustomControllerBase
    {
        private readonly ICacheBL cacheBL;

        public CachesController(ICacheBL cacheBL, IUnitOfWorkFactory uowFactory, ILogger logger) : base(uowFactory, logger)
        {
            this.cacheBL = cacheBL;
        }
        
        public ActionResult Index()
        {
            var vm = cacheBL.GetAll();

            return View(vm);
        }

        public ActionResult Reset(string cacheKey)
        {
            cacheBL.Reset(cacheKey);

            return RedirectToAction("Index");
        }
    }
}