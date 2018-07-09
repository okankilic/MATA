using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MATA.Presentation.Web.Impls
{
    public class StoresVMFactory: IVMFactory<StoreDTO, StoresIndexVM>
    {
        readonly IStoreBL storeBL;
        readonly IProjectBL projectBL;
        readonly ICityBL cityBL;
        readonly IDTOFactory<StoreDTO> dtoFactory;

        public StoresVMFactory(IStoreBL storeBL,
            IProjectBL projectBL,
            ICityBL cityBL,
            IDTOFactory<StoreDTO> dtoFactory)
        {
            this.storeBL = storeBL;
            this.projectBL = projectBL;
            this.cityBL = cityBL;
            this.dtoFactory = dtoFactory;
        }

        public async Task<StoresIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new StoresIndexVM
            {
                PageSize = pageSize,
                TotalCount = storeBL.Count(uow),
                Stores = await storeBL.GetStores((page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}