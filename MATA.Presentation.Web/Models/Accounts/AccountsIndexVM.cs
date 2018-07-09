using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class AccountsIndexVM: BaseIndexViewModel
    {
        public IEnumerable<AccountDTO> Accounts { get; set; }
    }
}