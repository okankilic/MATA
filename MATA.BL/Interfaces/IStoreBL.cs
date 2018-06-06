using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IStoreBL: IEntityBL<StoreDTO>
    {
        IEnumerable<StoreDTO> GetStores(int skip, int take, MataDBEntities db);

        int GetProjectStoreCount(int projectID, MataDBEntities db);

        IEnumerable<StoreDTO> GetProjectStores(int projectID, int skip, int take, MataDBEntities db);
    }
}
