using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Countries;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class CountriesController : CustomEntityControllerBase<CountryDTO, CountriesIndexVM>
    {
        public CountriesController(IUnitOfWorkFactory uowFactory,
            ILogger logger,
            IDTOFactory<CountryDTO> dtoFactory,
            IVMFactory<CountryDTO, CountriesIndexVM> vmFactory,
            IBLFactory blFactory): base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {

        }
    }
}
