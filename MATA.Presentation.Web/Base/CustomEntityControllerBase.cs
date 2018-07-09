using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Base
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public abstract class CustomEntityControllerBase<TDTO, TIndexVM>: CustomControllerBase
    {
        protected const int DefaultPageSize = 10;

        protected readonly IVMFactory<TDTO, TIndexVM> vmFactory;
        protected readonly IEntityBL<TDTO> entityBL;

        readonly IDTOFactory<TDTO> dtoFactory;

        public CustomEntityControllerBase(IUnitOfWorkFactory uowFactory, 
            ILogger logger,
            IDTOFactory<TDTO> dtoFactory,
            IVMFactory<TDTO, TIndexVM> vmFactory,
            IEntityBL<TDTO> entityBL): base(uowFactory, logger)
        {
            this.dtoFactory = dtoFactory;
            this.vmFactory = vmFactory;
            this.entityBL = entityBL;
        }

        [HttpGet]
        public async virtual Task<ActionResult> Index(int page = 1)
        {
            TIndexVM vm;

            using (var uow = uowFactory.CreateNew())
            {
                vm = await vmFactory.CreateNewIndexVMAsync(page, DefaultPageSize, uow);
            }

            return View(vm);
        }

        public virtual ActionResult Details(int id)
        {
            TDTO dto;

            using (var uow = uowFactory.CreateNew())
            {
                dto = entityBL.Get(id, uow);
            }

            return PartialView(dto);
        }

        [HttpGet]
        public virtual ActionResult _Create()
        {
            TDTO dto = dtoFactory.CreateNew();

            return PartialView(dto);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Create(TDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", dto);
            }

            using (var uow = uowFactory.CreateNew())
            {
                entityBL.Create(dto, TokenString, uow);
                uow.Commit();
            }

            return new ContentResult
            {
                Content = "OK"
            };
        }

        [HttpGet]
        public virtual ActionResult _Edit(int id)
        {
            TDTO dto;

            using (var uow = uowFactory.CreateNew())
            {
                dto = entityBL.Get(id, uow);
            }

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

            using (var uow = uowFactory.CreateNew())
            {
                entityBL.Update(id, dto, TokenString, uow);
                uow.Commit();
            }

            return new ContentResult
            {
                Content = "OK"
            };
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            using (var uow = uowFactory.CreateNew())
            {
                entityBL.Delete(id, TokenString, uow);
                uow.Commit();
            }

            return new ContentResult
            {
                Content = "OK"
            };
        }

        [HttpPost]
        public virtual async Task<JsonResult> Search(string q, int page)
        {
            IEnumerable<TDTO> items;

            using (var uow = uowFactory.CreateNew())
            {
                items = await entityBL.Search(q, (page - 1) * DefaultPageSize, DefaultPageSize, uow);
            }

            return Json(items);
        }

        //protected HtmlHelper<TDTO> GetHtmlHelper()
        //{
        //    return new HtmlHelper<TDTO>(new ViewContext(), new ViewPage());
        //}
    }
}