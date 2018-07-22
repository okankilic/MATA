using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class AttachmentBL : IAttachmentBL
    {
        readonly IMapper<Attachment, vAttachment, AttachmentDTO> mapper;

        public AttachmentBL(IMapper<Attachment, vAttachment, AttachmentDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.AttachmentRepository.GetCount();
        }

        public int Create(AttachmentDTO dto, string tokenString, IUnitOfWork uow)
        {
            var attachment = mapper.MapToEntity(dto);

            uow.AttachmentRepository.Create(attachment);
            uow.SaveChanges(tokenString);

            return attachment.ID;
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var attachment = uow.AttachmentRepository.GetByID(id);

            uow.AttachmentRepository.Delete(attachment);
            uow.SaveChanges(tokenString);
        }

        public AttachmentDTO Get(int id, IUnitOfWork uow)
        {
            var attachment = uow.AttachmentRepository.GetViewByID(id);

            return mapper.MapToDTO(attachment);
        }

        public async Task<IEnumerable<AttachmentDTO>> GetIssueAttachments(int issueID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.AttachmentRepository.Find(q => q.EntityName == nameof(Issue) && q.EntityID == issueID);

            return await OrderAttachments(items, skip, take);
        }

        public int GetIssueAttachmentsCount(int issueID, IUnitOfWork uow)
        {
            return uow.AttachmentRepository.GetCount(q => q.EntityName == nameof(Issue) && q.EntityID == issueID);
        }

        public async Task<IEnumerable<AttachmentDTO>> GetProjectAttachments(int projectID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.AttachmentRepository.Find(q => q.EntityName == nameof(Project) && q.EntityID == projectID);

            return await OrderAttachments(items, skip, take);
        }

        public int GetProjectAttachmentsCount(int projectID, IUnitOfWork uow)
        {
            return uow.AttachmentRepository.GetCount(q => q.EntityName == nameof(Project) && q.EntityID == projectID);
        }

        public async Task<IEnumerable<AttachmentDTO>> GetStoreAttachments(int storeID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.AttachmentRepository.Find(q => q.EntityName == nameof(Store) && q.EntityID == storeID);

            return await OrderAttachments(items, skip, take);
        }

        public int GetStoreAttachmentsCount(int storeID, IUnitOfWork uow)
        {
            return uow.AttachmentRepository.GetCount(q => q.EntityName == nameof(Store) && q.EntityID == storeID);
        }

        public Task<IEnumerable<AttachmentDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.AttachmentRepository.Find(a => a.FileName.Contains(q));

            return OrderAttachments(items, skip, take);
        }

        public void Update(int id, AttachmentDTO dto, string tokenString, IUnitOfWork uow)
        {
            var attachment = uow.AttachmentRepository.GetByID(id);

            attachment.FileName = dto.FileName;

            uow.AttachmentRepository.Update(attachment);
            uow.SaveChanges(tokenString);
        }

        private async Task<IEnumerable<AttachmentDTO>> OrderAttachments(IQueryable<vAttachment> items, int skip, int take)
        {
            var itemList = await items.OrderBy(q => q.FileName).ThenBy(q => q.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(q => mapper.MapToDTO(q));
        }
    }
}
