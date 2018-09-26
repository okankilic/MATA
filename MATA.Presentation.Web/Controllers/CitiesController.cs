using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Cities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class CitiesController : CustomEntityControllerBase<CityDTO, CitiesIndexVM>
    {
        readonly ICountryBL countryBL;
        readonly ICityBL cityBL;

        public CitiesController(IUnitOfWorkFactory uowFactory, 
            ILogger logger,
            IDTOFactory<CityDTO> dtoFactory,
            IVMFactory<CityDTO, CitiesIndexVM> vmFactory, 
            IBLFactory blFactory) : base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {
            countryBL = blFactory.CreateProxy<ICountryBL>();
            cityBL = blFactory.CreateProxy<ICityBL>();
        }

        public async Task<ActionResult> _CitySelect(int selectedCityID)
        {
            ViewData["SelectedCityID"] = selectedCityID;

            IEnumerable<CityDTO> cities = null;

            using (var uow = uowFactory.CreateNew())
            {
                cities = await cityBL.Search(null, 0, 0, uow);
            }

            return PartialView(cities);
        }

        public async Task<ActionResult> _CountryCities(int countryID, int page = 1)
        {
            CitiesIndexVM vm;

            using (var uow = uowFactory.CreateNew())
            {
                var country = countryBL.Get(countryID, uow);
                
                ViewBag.CountryID = country.ID;
                ViewBag.CountryName = country.CountryName;

                vm = new CitiesIndexVM
                {
                    PageSize = DefaultPageSize5,
                    TotalCount = cityBL.GetCountryCitiesCount(countryID, uow),
                    Cities = await cityBL.GetCountryCities(countryID, (page - 1) * DefaultPageSize5, DefaultPageSize5, uow)
                };
            }

            return PartialView(vm);
        }
    }
}