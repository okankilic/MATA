using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Stores;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    [AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
    public class StoresController : CustomEntityControllerBase<StoreDTO, StoresIndexVM>
    {
        readonly IStoreBL storeBL;
        readonly IAccountBL accountBL;
        readonly IProjectBL projectBL;
        readonly ICityBL cityBL;
        readonly IDTOFactory<StoreDTO> dtoFactory;

        public StoresController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<StoreDTO> dtoFactory,
            IVMFactory<StoreDTO, StoresIndexVM> vmFactory,
            IBLFactory blFactory) : base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {
            storeBL = blFactory.CreateProxy<IStoreBL>();
            accountBL = blFactory.CreateProxy<IAccountBL>();
            projectBL = blFactory.CreateProxy<IProjectBL>();
            cityBL = blFactory.CreateProxy<ICityBL>();

            this.dtoFactory = dtoFactory;
        }
        
        public override async Task<ActionResult> _Create(StoreDTO dto = null)
        {
            if(dto == null)
            {
                dto = dtoFactory.CreateNew();
            }

            using (var uow = uowFactory.CreateNew())
            {
                if(dto.CityID > 0)
                {
                    var city = cityBL.Get(dto.CityID, uow);

                    dto.CountryID = city.CountryID;
                    dto.CountryName = city.CountryName;
                    dto.CityID = city.ID;
                    dto.CityName = city.CityName;
                }

                if (dto.ProjectID > 0)
                {
                    var project = projectBL.Get(dto.ProjectID, uow);

                    dto.ProjectName = project.ProjectName;
                }

                dto.Accounts = await accountBL.Search(null, 0, accountBL.Count(uow), uow);
            }

            return PartialView(dto);
        }

        public override async Task<ActionResult> _Edit(int id)
        {
            StoreDTO dto;

            using (var uow = uowFactory.CreateNew())
            {
                dto = storeBL.Get(id, uow);
                dto.Accounts = await accountBL.Search(null, 0, accountBL.Count(uow), uow);
            }

            return PartialView(dto);
        }

        public async Task<ActionResult> _CountryStores(int countryID, int page = 1)
        {
            StoresIndexVM vm;

            ViewBag.CountryID = countryID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new StoresIndexVM
                {
                    PageSize = DefaultPageSize5,
                    TotalCount = storeBL.GetCountryStoresCount(countryID, uow),
                    Stores = await storeBL.GetCountryStores(countryID, (page - 1) * DefaultPageSize5, DefaultPageSize5, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _CityStores(int cityID, int page = 1)
        {
            StoresIndexVM vm;

            ViewBag.CityID = cityID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new StoresIndexVM
                {
                    PageSize = DefaultPageSize10,
                    TotalCount = storeBL.GetCityStoresCount(cityID, uow),
                    Stores = await storeBL.GetCityStores(cityID, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _ProjectStores(int projectID, int page = 1)
        {
            StoresIndexVM vm;

            ViewBag.ProjectID = projectID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new StoresIndexVM
                {
                    PageSize = DefaultPageSize10,
                    TotalCount = storeBL.GetProjectStoreCount(projectID, uow),
                    Stores = await storeBL.GetProjectStores(projectID, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow)
                };
            }

            return PartialView(vm);
        }
    }
}
