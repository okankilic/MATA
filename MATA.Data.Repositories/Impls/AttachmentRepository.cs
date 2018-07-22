using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class AttachmentRepository : GenericRepository<Attachment, vAttachment>
    {
        public AttachmentRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }
    }
}
