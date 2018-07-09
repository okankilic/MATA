using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class StoreRepository : GenericRepository<Store, vStore>
    {
        public StoreRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<vStore>> GetStores(int skip, int take)
        {
            var storeList = new List<vStore>();

            var stores = dbSetView.OrderBy(q => q.ID).ThenBy(q => q.StoreName);

            if (skip == 0 && take == 0)
            {
                storeList = await stores.ToListAsync();
            }
            else
            {
                storeList = await stores.Skip(skip).Take(take).ToListAsync();
            }

            return storeList;
        }

        public IEnumerable<vStore> GetProjectStores(int projectID, int skip, int take)
        {
            return dbSetView.Where(q => q.ProjectID == projectID).OrderBy(q => q.ID).ThenBy(q => q.ProjectName).Skip(skip).Take(take).ToList();
        }
    }
}
