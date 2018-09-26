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
        where TDTO: class
        where TIndexVM: class
    {
        protected readonly IVMFactory<TDTO, TIndexVM> vmFactory;
        
        readonly IDTOFactory<TDTO> dtoFactory;
        readonly IBLFactory blFactory;
        readonly IEntityBL<TDTO> entityBL;

        public CustomEntityControllerBase(IUnitOfWorkFactory uowFactory, 
            ILogger logger,
            IDTOFactory<TDTO> dtoFactory,
            IVMFactory<TDTO, TIndexVM> vmFactory,
            IBLFactory blFactory): base(uowFactory, logger)
        {
            this.dtoFactory = dtoFactory;
            this.vmFactory = vmFactory;
            this.blFactory = blFactory;
            //this.entityBL = entityBL;
            this.entityBL = blFactory.CreateProxy<IEntityBL<TDTO>>();
        }

        [HttpGet]
        public async virtual Task<ActionResult> Index(int page = 1)
        {
            TIndexVM vm;

            using (var uow = uowFactory.CreateNew())
            {
                vm = await vmFactory.CreateNewIndexVMAsync(page, DefaultPageSize10, uow);
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
        public virtual async Task<ActionResult> _Create(TDTO dto = null)
        {
            if(dto == null)
            {
                dto = await Task.Factory.StartNew(() =>
                {
                    return dtoFactory.CreateNew();
                });
            }

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
        public virtual async Task<ActionResult> _Edit(int id)
        {
            TDTO dto = await Task.Factory.StartNew(() =>
            {
                using (var uow = uowFactory.CreateNew())
                {
                    return entityBL.Get(id, uow);
                }
            });

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
                items = await entityBL.Search(q, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow);
            }

            return Json(items);
        }

        //protected HtmlHelper<TDTO> GetHtmlHelper()
        //{
        //    return new HtmlHelper<TDTO>(new ViewContext(), new ViewPage());
        //}
    }
}