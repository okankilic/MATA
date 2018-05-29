using MATA.BL;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class ProjectController : CustomControllerBase
    {
        // GET: Project
        public ActionResult Index(int page = 1)
        {
            int take = 20, 
                skip = (page - 1) * 20;

            var projects = ProjectBL.GetProjects(skip, take, _DB);

            return View(projects);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var project = ProjectBL.Get(id, _DB);

            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var project = new ProjectDTO();

            return View(project);
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(projectDTO);
            }

            var projectID = ProjectBL.Create(projectDTO, _DB);

            return RedirectToAction("Index");
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var project = ProjectBL.Get(id, _DB);

            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(projectDTO);
            }

            ProjectBL.Update(id, projectDTO, _DB);

            return RedirectToAction("Index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            var project = ProjectBL.Get(id, _DB);

            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ProjectBL.Delete(id, _DB);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
