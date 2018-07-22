using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;

namespace MATA.BL.Interfaces
{
    public interface IAttachmentBL: IEntityBL<AttachmentDTO>, ISearchable<AttachmentDTO>
    {
        int GetProjectAttachmentsCount(int projectID, IUnitOfWork uow);

        Task<IEnumerable<AttachmentDTO>> GetProjectAttachments(int projectID, int skip, int take, IUnitOfWork uow);

        int GetStoreAttachmentsCount(int storeID, IUnitOfWork uow);

        Task<IEnumerable<AttachmentDTO>> GetStoreAttachments(int storeID, int skip, int take, IUnitOfWork uow);

        int GetIssueAttachmentsCount(int issueID, IUnitOfWork uow);

        Task<IEnumerable<AttachmentDTO>> GetIssueAttachments(int issueID, int skip, int take, IUnitOfWork uow);
    }
}
