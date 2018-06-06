using MATA.BL.Interfaces;
using MATA.Data.Entities;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Impls
{
    public class CountryVMFactory : IVMFactory<CountriesIndexVM>
    {
        readonly ICountryBL countryBL;

        public CountryVMFactory(ICountryBL countryBL)
        {
            this.countryBL = countryBL;
        }

        public CountriesIndexVM CreateIndexVM(int page, int pageSize, MataDBEntities db)
        {
            return new CountriesIndexVM
            {
                PageSize = pageSize,
                TotalCount = countryBL.Count(db),
                Countries = countryBL.GetCountries((page - 1) * pageSize, pageSize, db)
            };
        }
    }
}