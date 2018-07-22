using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class MailRepository : GenericRepository<Mail, vMail>
    {
        public MailRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }
    }
}
