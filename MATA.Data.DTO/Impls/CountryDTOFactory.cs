using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public class CountryDTOFactory : DTOFactory<CountryDTO>
    {
        public override CountryDTO CreateNew()
        {
            return new CountryDTO();
        }
    }
}
