using MATA.BL;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public class StoresController : CustomEntityControllerBase<StoreDTO>
    {
        public override ActionResult Index(int page = 1)
        {
            var model = new StoresIndexViewModel
            {
                PageSize = DefaultPageSize,
                TotalCount = StoreBL.GetStoreCount(_DB),
                Stores = StoreBL.GetStores((page - 1) * DefaultPageSize, DefaultPageSize, _DB)
            };

            return View(model);
        }

        public ActionResult _Index(int projectID, int page = 1)
        {
            var model = new StoresIndexViewModel
            {
                PageSize = DefaultPageSize,
                TotalCount = StoreBL.GetProjectStoreCount(projectID, _DB),
                Stores = StoreBL.GetProjectStores(projectID, (page - 1) * DefaultPageSize, DefaultPageSize, _DB)
            };

            return PartialView(model);
        }

        public override ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult _Create()
        {
            var model = new StoreDTO();

            return PartialView(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public override ActionResult Create(StoreDTO storeDTO)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", storeDTO);
            }

            var projectID = StoreBL.Create(storeDTO, TokenString, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }

        public override ActionResult _Edit(int id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Edit(int id, StoreDTO dto)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
