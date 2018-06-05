using MATA.BL;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using MATA.Presentation.Web.Models;
using MATA.Presentation.Web.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    
    public class ProjectsController : CustomEntityControllerBase<ProjectDTO>
    {
        // GET: Project
        public override ActionResult Index(int page = 1)
        {
            var model = new ProjectsIndexViewModel
            {
                TotalCount = ProjectBL.GetCount(_DB),
                PageSize = DefaultPageSize,
                Projects = ProjectBL.GetProjects((page - 1) * DefaultPageSize, DefaultPageSize, _DB)
            };

            return View(model);
        }

        // GET: Project/Details/5
        public override ActionResult Details(int id)
        {
            var project = ProjectBL.Get(id, _DB);

            return PartialView(project);
        }

        // GET: Project/Create
        public override ActionResult _Create()
        {
            var project = new ProjectDTO();

            return PartialView(project);
        }

        // POST: Project/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public override ActionResult Create(ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", projectDTO);
            }

            var projectID = ProjectBL.Create(projectDTO, TokenString, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }

        // GET: Project/Edit/5
        public override ActionResult _Edit(int id)
        {
            var project = ProjectBL.Get(id, _DB);

            return PartialView(project);
        }

        // POST: Project/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public override ActionResult Edit(int id, ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Edit", projectDTO);
            }

            ProjectBL.Update(id, projectDTO, TokenString, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }

        // POST: Project/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public override ActionResult Delete(int id)
        {
            var result = new CustomJsonResult();

            ProjectBL.Delete(id, _DB);

            return new ContentResult
            {
                Content = "OK"
            };
        }
    }
}
