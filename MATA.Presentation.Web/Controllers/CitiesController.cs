using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class CitiesController : CustomEntityControllerBase<CityDTO, CitiesIndexVM>
    {
        public CitiesController(IVMFactory<CitiesIndexVM> vmFactory, IDTOFactory<CityDTO> dtoFactory, IEntityBL<CityDTO> entityBL) : base(vmFactory, dtoFactory, entityBL)
        {
        }
    }
}