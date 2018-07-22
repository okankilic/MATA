using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Actions
{
    public class ActionsIndexVM: BaseIndexViewModel
    {
        public IEnumerable<ActionDTO> Actions { get; set; }
    }
}