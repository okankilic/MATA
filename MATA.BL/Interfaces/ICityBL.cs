using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface ICityBL: IEntityBL<CityDTO>
    {
        int GetCountryCitiesCount(int countryID, IUnitOfWork uow);

        Task<IEnumerable<CityDTO>> GetCountryCities(int countryID, int skip, int take, IUnitOfWork uow);
    }
}
