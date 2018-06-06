using MATA.BL.Interfaces;
using MATA.Data.Entities;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Impls
{
    public class CitiesVMFactory : IVMFactory<CitiesIndexVM>
    {
        readonly ICityBL cityBL;

        public CitiesVMFactory(ICityBL cityBL)
        {
            this.cityBL = cityBL;
        }

        public CitiesIndexVM CreateIndexVM(int page, int pageSize, MataDBEntities db)
        {
            return new CitiesIndexVM
            {
                PageSize = pageSize,
                TotalCount = cityBL.Count(db),
                Cities = cityBL.GetCities((page - 1) * pageSize, pageSize, db)
            };
        }
    }
}