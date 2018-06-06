using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class CountriesController : CustomEntityControllerBase<CountryDTO, CountriesIndexVM>
    {
        public CountriesController(
            IVMFactory<CountriesIndexVM> vmFactory,
            IDTOFactory<CountryDTO> dtoFactory,
            IEntityBL<CountryDTO> entityBL): base(vmFactory, dtoFactory, entityBL)
        {

        }
    }
}
