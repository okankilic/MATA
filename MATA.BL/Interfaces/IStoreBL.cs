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

        int GetProjectStoreCount(int projectID, IUnitOfWork uow);

        IEnumerable<StoreDTO> GetProjectStores(int projectID, int skip, int take, IUnitOfWork uow);
    }
}
