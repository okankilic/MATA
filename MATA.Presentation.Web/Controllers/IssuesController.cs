using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class IssuesController : CustomEntityControllerBase<IssueDTO, IssuesIndexViewModel>
    {
        public IssuesController(
            IVMFactory<IssuesIndexViewModel> vmFactory,
            IDTOFactory<IssueDTO> dtoFactory,
            IEntityBL<IssueDTO> entityBL) : base(vmFactory, dtoFactory, entityBL)
        {

        }
    }
}
