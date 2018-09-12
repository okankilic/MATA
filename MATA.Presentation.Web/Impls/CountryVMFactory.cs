using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models;
using MATA.Presentation.Web.Models.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Impls
{
    public class CountryVMFactory : IVMFactory<CountryDTO, CountriesIndexVM>
    {
        readonly ICountryBL countryBL;

        public CountryVMFactory(IBLFactory blFactory)
        {
            this.countryBL = blFactory.CreateProxy<ICountryBL>();
        }

        public async Task<CountriesIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new CountriesIndexVM
            {
                PageSize = pageSize,
                TotalCount = countryBL.Count(uow),
                Countries = await countryBL.Search(null, (page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}