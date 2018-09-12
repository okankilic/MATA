using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Impls
{
    public class ProjectsVMFactory : IVMFactory<ProjectDTO, ProjectsIndexVM>
    {
        readonly IProjectBL projectBL;
        readonly IDTOFactory<ProjectDTO> dtoFactory;

        public ProjectsVMFactory(IBLFactory blFactory,
            IDTOFactory<ProjectDTO> dtoFactory)
        {
            this.projectBL = blFactory.CreateProxy<IProjectBL>();
            this.dtoFactory = dtoFactory;
        }

        public async Task<ProjectsIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new ProjectsIndexVM
            {
                PageSize = pageSize,
                TotalCount = projectBL.Count(uow),
                Projects = await projectBL.Search(null, (page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}