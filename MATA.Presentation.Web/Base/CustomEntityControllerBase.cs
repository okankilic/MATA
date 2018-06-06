using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Base
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public abstract class CustomEntityControllerBase<TDTO, TIndexVM>: CustomControllerBase
    {
        protected const int DefaultPageSize = 10;

        readonly IVMFactory<TIndexVM> vmFactory;
        readonly IDTOFactory<TDTO> dtoFactory;
        readonly IEntityBL<TDTO> entityBL;

        public CustomEntityControllerBase(IVMFactory<TIndexVM> vmFactory,
            IDTOFactory<TDTO> dtoFactory,
            IEntityBL<TDTO> entityBL)
        {
            this.vmFactory = vmFactory;
            this.dtoFactory = dtoFactory;
            this.entityBL = entityBL;
        }

        public virtual ActionResult Index(int page = 1)
        {
            var model = vmFactory.CreateIndexVM(page, DefaultPageSize, _DB);

            return View(model);
        }

        public virtual ActionResult _Index(int projectID, int page = 1)
        {
            var model = vmFactory.CreateIndexVM(page, DefaultPageSize, _DB);

            return PartialView(model);
        }

        public virtual ActionResult Details(int id)
        {
            var project = entityBL.Get(id, _DB);

            return PartialView(project);
        }

        public virtual ActionResult _Create()
        {
            var model = dtoFactory.CreateNew();

            return PartialView(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Create(TDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", dto);
            }

            var entityID = entityBL.Create(dto, TokenString, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }

        public virtual ActionResult _Edit(int id)
        {
            var dto = entityBL.Get(id, _DB);

            return PartialView(dto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Edit(int id, TDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Edit", dto);
            }

            entityBL.Update(id, dto, TokenString, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            entityBL.Delete(id, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }
    }
}