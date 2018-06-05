using MATA.BL;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class IssuesController : CustomEntityControllerBase<IssueDTO>
    {
        public override ActionResult Index(int page = 1)
        {
            throw new NotImplementedException();
        }

        public ActionResult _Index(int projectID, int page = 1)
        {
            var model = new IssuesIndexViewModel
            {
                PageSize = DefaultPageSize,
                TotalCount = IssueBL.GetProjectIssueCount(projectID, _DB),
                Issues = IssueBL.GetProjectIssues(projectID, (page - 1) * DefaultPageSize, DefaultPageSize, _DB)
            };

            return PartialView(model);
        }

        public override ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult _Create()
        {
            throw new NotImplementedException();
        }

        public override ActionResult Create(IssueDTO dto)
        {
            throw new NotImplementedException();
        }

        public override ActionResult _Edit(int id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Edit(int id, IssueDTO dto)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
