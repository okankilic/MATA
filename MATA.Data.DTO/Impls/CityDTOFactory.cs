using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public class CityDTOFactory : DTOFactory<CityDTO>
    {
        public override CityDTO CreateNew()
        {
            return new CityDTO();
        }
    }
}
