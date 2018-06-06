using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.Entities;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Impls
{
    public class StoresVMFactory: IVMFactory<StoresIndexVM>
    {
        readonly IStoreBL storeBL;

        public StoresVMFactory(IStoreBL storeBL)
        {
            this.storeBL = storeBL;
        }

        public StoresIndexVM CreateIndexVM(int page, int pageSize, MataDBEntities db)
        {
            return new StoresIndexVM
            {
                PageSize = pageSize,
                TotalCount = storeBL.Count(db),
                Stores = storeBL.GetStores((page - 1) * pageSize, pageSize, db)
            };
        }
    }
}