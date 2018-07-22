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
    public interface IStoreBL: IEntityBL<StoreDTO>
    {
        Task<IEnumerable<StoreDTO>> GetStores(int skip, int take, IUnitOfWork uow);

        int GetCountryStoresCount(int countryID, IUnitOfWork uow);

        Task<IEnumerable<StoreDTO>> GetCountryStores(int countryID, int skip, int take, IUnitOfWork uow);

        int GetCityStoresCount(int cityID, IUnitOfWork uow);

        Task<IEnumerable<StoreDTO>> GetCityStores(int cityID, int skip, int take, IUnitOfWork uow);

        int GetProjectStoreCount(int projectID, IUnitOfWork uow);

        Task<IEnumerable<StoreDTO>> GetProjectStores(int projectID, int skip, int take, IUnitOfWork uow);
    }
}
