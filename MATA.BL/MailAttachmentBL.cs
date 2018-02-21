using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public static class MailAttachmentBL
    {
        public static IEnumerable<vMailAttachment> GetList(int mailID, MataDBEntities db)
        {
            return db.vMailAttachment.Where(q => q.MailID == mailID).ToList();
        }
    }
}
