using MATA.BL.Interfaces;
using MATA.Data.Common.Enums;
using MATA.Data.DTO;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public static class MailBL: IMailBL
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

        public static void Create(MailDTO mail)
        {

        }

        public async Task QueueMail(string email, MailTypes mailType, IUnitOfWork uow)
        {
            var account = await uow.AccountRepository.GetByEmail(email);

        }
    }
}
