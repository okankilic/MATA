using MATA.Data.Common.Enums;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public static class MailBL
    {
        public static IEnumerable<Mail> GetList(int maxTryCount, int count, MataDBEntities db)
        {
            return db.Mail.Where(q => q.State != MailStateTypes.ERROR.ToString() && q.TryCount < maxTryCount).OrderBy(q => q.TryCount).ThenBy(q => q.ID).Take(count).ToList();
        }

        public static void UpdateState(int id, MailStateTypes state, int tryCount, MataDBEntities db)
        {
            var mail = db.Mail.Single(q => q.ID == id);

            mail.TryCount = tryCount;
            mail.State = state.ToString();

            db.SaveChanges();
        }
    }
}
