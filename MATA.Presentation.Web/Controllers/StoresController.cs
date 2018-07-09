﻿using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Stores;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public class StoresController : CustomEntityControllerBase<StoreDTO, StoresIndexVM>
    {
        public StoresController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<StoreDTO> dtoFactory,
            IVMFactory<StoreDTO, StoresIndexVM> vmFactory,
            IEntityBL<StoreDTO> entityBL) : base(uowFactory, logger, dtoFactory, vmFactory, entityBL)
        {

        }

        public async Task<ActionResult> _Index(int projectID, int page = 1)
        {
            var uow = uowFactory.CreateNew();

            var model = await vmFactory.CreateNewIndexVMAsync(page, DefaultPageSize, uow);

            return PartialView(model);
        }
    }
}
