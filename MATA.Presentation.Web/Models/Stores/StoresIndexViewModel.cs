using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Stores
{
    public class StoresIndexViewModel: BaseIndexViewModel
    {
        public IEnumerable<StoreDTO> Stores { get; set; }
    }
}