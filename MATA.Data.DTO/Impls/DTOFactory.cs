using MATA.Data.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public abstract class DTOFactory<TDTO>: IDTOFactory<TDTO>
    {
        public abstract TDTO CreateNew();
    }
}
