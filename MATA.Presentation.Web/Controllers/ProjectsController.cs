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
        public ProjectsController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<ProjectDTO> dtoFactory,
            IVMFactory<ProjectDTO, ProjectsIndexVM> vmFactory,
            IBLFactory blFactory): base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {

        }
    }
}
