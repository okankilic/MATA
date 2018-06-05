using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Projects
{
    public class ProjectsIndexViewModel: BaseIndexViewModel
    {
        public IEnumerable<ProjectDTO> Projects { get; set; }
    }
}