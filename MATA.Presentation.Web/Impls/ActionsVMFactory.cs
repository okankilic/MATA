using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MATA.Presentation.Web.Impls
{
    public class ActionsVMFactory : IVMFactory<ActionDTO, ActionsIndexVM>
    {
        readonly IActionBL actionBL;
        readonly IDTOFactory<ActionDTO> dtoFactory;

        public ActionsVMFactory(IBLFactory blFactory,
            IDTOFactory<ActionDTO> dtoFactory)
        {
            actionBL = blFactory.CreateProxy<IActionBL>();

            this.dtoFactory = dtoFactory;
        }

        public async Task<ActionsIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new ActionsIndexVM
            {
                PageSize = pageSize,
                TotalCount = actionBL.Count(uow),
                Actions = await actionBL.Search(null, (page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}