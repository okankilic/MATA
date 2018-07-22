using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class StoreAccountRepository : GenericRepository<StoreAccount, vStoreAccount>
    {
        public StoreAccountRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }

        public IList<StoreAccount> GetStoreAccountList(int storeID)
        {
            return dbSetEntity.Where(q => q.StoreID == storeID).ToList();
        }

        public IList<int> GetStoreAccountIDList(int storeID)
        {
            return GetStoreAccountList(storeID).Select(q => q.AccountID).ToList();
        }
    }
}
