using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Cities
{
    public class CitiesIndexVM: BaseIndexViewModel
    {
        public IEnumerable<CityDTO> Cities { get; set; }
    }
}