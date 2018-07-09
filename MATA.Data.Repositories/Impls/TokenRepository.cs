using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class TokenRepository : GenericRepository<Token, vToken>
    {
        public TokenRepository(MataDBEntities dbContext) : base(dbContext)
        {

        }
    }
}
