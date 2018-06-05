using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class CountriesController : CustomEntityControllerBase<CountryDTO>
    {
        public override ActionResult Index(int page = 1)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult _Create()
        {
            throw new NotImplementedException();
        }

        public override ActionResult Create(CountryDTO dto)
        {
            throw new NotImplementedException();
        }

        public override ActionResult _Edit(int id)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Edit(int id, CountryDTO dto)
        {
            throw new NotImplementedException();
        }

        public override ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
