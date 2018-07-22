using MATA.Data.Common.Enums;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class AttachmentMapper : IMapper<Attachment, vAttachment, AttachmentDTO>
    {
        public AttachmentDTO MapToDTO(vAttachment view)
        {
            return new AttachmentDTO
            {
                ID = view.ID,
                AttachmentType = (AttachmentTypes)Enum.Parse(typeof(AttachmentTypes), view.AttachmentType),
                EntityName = view.EntityName,
                EntityID = view.EntityID,
                FileName = view.FileName,
                FilePath = view.FilePath,
                CreatedByAccountID = view.CreatedByAccountID,
                CreatedBy = view.CreatedBy,
                CreateTime = view.CreateTime,
                UpdatedByAccountID = view.UpdatedByAccountID,
                UpdatedBy = view.UpdatedBy,
                UpdateTime = view.UpdateTime
            };
        }

        public Attachment MapToEntity(AttachmentDTO dto)
        {
            return new Attachment
            {
                ID = dto.ID,
                AttachmentType = dto.AttachmentType.ToString(),
                EntityName = dto.EntityName,
                EntityID = dto.EntityID,
                FileName = dto.FileName,
                FilePath = dto.FilePath
            };
        }
    }
}
