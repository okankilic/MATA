using MATA.BL.Interfaces;
using MATA.Data.Entities;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Impls
{
    public class ProjectsVMFactory : IVMFactory<ProjectsIndexVM>
    {
        readonly IProjectBL projectBL;

        public ProjectsVMFactory(IProjectBL projectBL)
        {
            this.projectBL = projectBL;
        }

        public ProjectsIndexVM CreateIndexVM(int page, int pageSize, MataDBEntities db)
        {
            return new ProjectsIndexVM
            {
                PageSize = pageSize,
                TotalCount = projectBL.Count(db),
                Projects = projectBL.GetProjects((page - 1) * pageSize, pageSize, db)
            };
        }
    }
}