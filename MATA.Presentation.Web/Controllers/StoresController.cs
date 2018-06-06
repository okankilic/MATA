using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public class StoresController : CustomEntityControllerBase<StoreDTO, StoresIndexVM>
    {
        public StoresController(
            IVMFactory<StoresIndexVM> vmFactory,
            IDTOFactory<StoreDTO> dtoFactory,
            IEntityBL<StoreDTO> entityBL) : base(vmFactory, dtoFactory, entityBL)
        {

        }
    }
}
