using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Countries
{
    public class CountriesIndexVM: BaseIndexViewModel
    {
        public IEnumerable<CountryDTO> Countries { get; set; }
    }
}