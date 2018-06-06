using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface ICityBL: IEntityBL<CityDTO>
    {
        IEnumerable<CityDTO> GetCities(int skip, int take, MataDBEntities db);
    }
}
