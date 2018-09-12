using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models;
using MATA.Presentation.Web.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MATA.Presentation.Web.Impls
{
    public class CitiesVMFactory : IVMFactory<CityDTO, CitiesIndexVM>
    {
        readonly ICityBL cityBL;
        readonly ICountryBL countryBL;
        readonly IDTOFactory<CityDTO> dtoFactory;

        public CitiesVMFactory(
            IDTOFactory<CityDTO> dtoFactory,
            IBLFactory blFactory)
        {
            this.cityBL = blFactory.CreateProxy<ICityBL>();
            this.countryBL = blFactory.CreateProxy<ICountryBL>();
            this.dtoFactory = dtoFactory;
        }

        public async Task<CitiesIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new CitiesIndexVM
            {
                PageSize = pageSize,
                TotalCount = cityBL.Count(uow),
                Cities = await cityBL.Search(null, (page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}