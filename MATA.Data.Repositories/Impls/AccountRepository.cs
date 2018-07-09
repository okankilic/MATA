using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class AccountRepository : GenericRepository<Account, vAccount>
    {
        public AccountRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }

        public async Task<vAccount> GetByEmail(string email)
        {
            return await dbSetView.SingleAsync(q => q.Email == email);
        }

        public async Task<IEnumerable<vAccount>> GetAccounts(int skip, int take)
        {
            var accountList = new List<vAccount>();

            var accounts = dbSetView.OrderBy(q => q.Email).ThenBy(q => q.FullName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                accountList = await accounts.ToListAsync();
            }
            else
            {
                accountList = await accounts.Skip(skip).Take(take).ToListAsync();
            }

            return accountList;
        }
    }
}
