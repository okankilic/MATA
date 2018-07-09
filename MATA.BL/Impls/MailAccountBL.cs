using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public static class MailAccountBL
    {
        public static IEnumerable<vMailAccount> GetList(int mailID, MataDBEntities db)
        {
            return db.vMailAccount.Where(q => q.MailID == mailID).ToList();
        }
    }
}
