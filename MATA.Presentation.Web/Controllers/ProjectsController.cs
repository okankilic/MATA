using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models;
using MATA.Presentation.Web.Models.Projects;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    
    public class ProjectsController : CustomEntityControllerBase<ProjectDTO, ProjectsIndexVM>
    {
        readonly IProjectBL projectBL;

        public ProjectsController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<ProjectDTO> dtoFactory,
            IVMFactory<ProjectDTO, ProjectsIndexVM> vmFactory,
            IBLFactory blFactory): base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {
            projectBL = blFactory.CreateProxy<IProjectBL>();
        }

        public async Task<ActionResult> _CountryProjects(int countryID, int page = 1)
        {
            ProjectsIndexVM vm;

            ViewBag.CountryID = countryID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new ProjectsIndexVM
                {
                    PageSize = DefaultPageSize5,
                    TotalCount = projectBL.GetCountryProjectsCount(countryID, uow),
                    Projects = await projectBL.GetCountryProjects(countryID, (page - 1) * DefaultPageSize5, DefaultPageSize5, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _CityProjects(int cityID, int page = 1)
        {
            ProjectsIndexVM vm;

            ViewBag.CityID = cityID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new ProjectsIndexVM
                {
                    PageSize = DefaultPageSize5,
                    TotalCount = projectBL.GetCityProjectsCount(cityID, uow),
                    Projects = await projectBL.GetCityProjects(cityID, (page - 1) * DefaultPageSize5, DefaultPageSize5, uow)
                };
            }

            return PartialView(vm);
        }
    }
}
