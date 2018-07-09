using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public class IssueDTOFactory : DTOFactory<IssueDTO>
    {
        public override IssueDTO CreateNew()
        {
            return new IssueDTO();
        }
    }
}
