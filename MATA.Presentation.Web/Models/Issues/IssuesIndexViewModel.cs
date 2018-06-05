using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Issues
{
    public class IssuesIndexViewModel: BaseIndexViewModel
    {
        public IEnumerable<IssueDTO> Issues { get; set; }
    }
}