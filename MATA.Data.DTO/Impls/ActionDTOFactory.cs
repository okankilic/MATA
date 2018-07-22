using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public class ActionDTOFactory : IDTOFactory<ActionDTO>
    {
        public ActionDTO CreateNew()
        {
            return new ActionDTO();
        }
    }
}
