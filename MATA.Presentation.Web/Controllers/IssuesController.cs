using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Issues;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class IssuesController : CustomEntityControllerBase<IssueDTO, IssuesIndexVM>
    {
        public IssuesController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<IssueDTO> dtoFactory,
            IVMFactory<IssueDTO, IssuesIndexVM> vmFactory,
            IEntityBL<IssueDTO> entityBL) : base(uowFactory, logger, dtoFactory, vmFactory, entityBL)
        {

        }

        public async Task<ActionResult> _Index(int projectID, int page = 1)
        {
            IssuesIndexVM vm = null;

            using (var uow = uowFactory.CreateNew())
            {
                vm = await vmFactory.CreateNewIndexVMAsync(page, DefaultPageSize, uow);
            }

            return PartialView(vm);
        }
    }
}
