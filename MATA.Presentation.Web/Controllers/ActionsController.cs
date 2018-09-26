using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Actions;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class ActionsController : CustomEntityControllerBase<ActionDTO, ActionsIndexVM>
    {
        readonly IActionBL actionBL;

        public ActionsController(IUnitOfWorkFactory uowFactory, 
            ILogger logger, 
            IDTOFactory<ActionDTO> dtoFactory, 
            IVMFactory<ActionDTO, ActionsIndexVM> vmFactory, 
            IBLFactory blFactory) : base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {
            actionBL = blFactory.CreateProxy<IActionBL>();
        }
        
        public async Task<ActionResult> _AccountActions(int accountID, int page = 1)
        {

            ActionsIndexVM vm;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new ActionsIndexVM
                {
                    PageSize = DefaultPageSize10,
                    TotalCount = actionBL.GetAccountActionsCount(accountID, uow),
                    Actions = await actionBL.GetAccountActions(accountID, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow)
                };
            }

            return PartialView(vm);
        }
    }
}