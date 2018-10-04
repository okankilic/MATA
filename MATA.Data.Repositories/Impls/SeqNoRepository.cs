using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class SeqNoRepository : GenericRepository<SeqNo, vSeqNo>
    {
        public SeqNoRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }
    }
}
