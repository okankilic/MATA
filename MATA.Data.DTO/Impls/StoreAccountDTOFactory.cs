using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public class StoreAccountDTOFactory : DTOFactory<StoreAccountDTO>
    {
        public override StoreAccountDTO CreateNew()
        {
            return new StoreAccountDTO();
        }
    }
}
