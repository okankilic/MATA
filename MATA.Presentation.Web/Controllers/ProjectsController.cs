using MATA.BL;
using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models;
using MATA.Presentation.Web.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    
    public class ProjectsController : CustomEntityControllerBase<ProjectDTO, ProjectsIndexVM>
    {
        public ProjectsController(
            IVMFactory<ProjectsIndexVM> vmFactory,
            IDTOFactory<ProjectDTO> dtoFactory,
            IEntityBL<ProjectDTO> entityBL): base(vmFactory, dtoFactory, entityBL)
        {

        }
    }
}
