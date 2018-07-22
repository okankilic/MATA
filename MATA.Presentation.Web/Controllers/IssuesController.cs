using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Issues;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class IssuesController : CustomEntityControllerBase<IssueDTO, IssuesIndexVM>
    {
        readonly IIssueBL issueBL;

        public IssuesController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<IssueDTO> dtoFactory,
            IVMFactory<IssueDTO, IssuesIndexVM> vmFactory,
            IBLFactory blFactory) : base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {
            issueBL = blFactory.CreateProxy<IIssueBL>();
        }

        public async Task<ActionResult> _CountryIssues(int countryID, int page = 1)
        {
            IssuesIndexVM vm = null;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new IssuesIndexVM
                {
                    PageSize = DefaultPageSize,
                    TotalCount = issueBL.GetCountryIssuesCount(countryID, uow),
                    Issues = await issueBL.GetCountryIssues(countryID, (page - 1) * DefaultPageSize, DefaultPageSize, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _CityIssues(int cityID, int page = 1)
        {
            IssuesIndexVM vm = null;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new IssuesIndexVM
                {
                    PageSize = DefaultPageSize,
                    TotalCount = issueBL.GetCityIssuesCount(cityID, uow),
                    Issues = await issueBL.GetCityIssues(cityID, (page - 1) * DefaultPageSize, DefaultPageSize, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _ProjectIssues(int projectID, int page = 1)
        {
            IssuesIndexVM vm = null;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new IssuesIndexVM
                {
                    PageSize = DefaultPageSize,
                    TotalCount = issueBL.GetProjectIssuesCount(projectID, uow),
                    Issues = await issueBL.GetProjectIssues(projectID, (page - 1) * DefaultPageSize, DefaultPageSize, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _StoreIssues(int storeID, int page = 1)
        {
            IssuesIndexVM vm = null;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new IssuesIndexVM
                {
                    PageSize = DefaultPageSize,
                    TotalCount = issueBL.GetStoreIssuesCount(storeID, uow),
                    Issues = await issueBL.GetStoreIssues(storeID, (page - 1) * DefaultPageSize, DefaultPageSize, uow)
                };
            }

            return PartialView(vm);
        }
    }
}
